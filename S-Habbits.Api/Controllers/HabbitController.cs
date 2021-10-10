using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S_Habbits.Data;
using S_Habbits.Data.Models;
using S_Habbits.Shared.ViewModel;
using Swashbuckle.AspNetCore.Annotations;

namespace S_Habbits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabbitController : ControllerBase
    {
        private readonly SHabbitsDbContext _db;
        private readonly IMapper _mapper;

        public HabbitController(SHabbitsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        [SwaggerOperation("Get All Habbits")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<HabbitViewModel>), 200)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var username = User.Identity?.Name;
            var habbitViewModels = _mapper.Map<IEnumerable<HabbitViewModel>>(
                _db.Habbits.Where(d => d.User.Username == username).ToList());
            foreach (var habbitViewModel in habbitViewModels)
                habbitViewModel.LastHabbitEvent = _mapper.Map<HabbitEventViewModel>(await _db.HabbitEvents
                    .OrderByDescending(d => d.DateTime)
                    .LastOrDefaultAsync(d => d.Habbit.Id == habbitViewModel.Id));
            return Ok(habbitViewModels);
        }


        [SwaggerOperation("Add new Habbit")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), 200)]
        [Route("Add")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(string message, int rewardPoints)
        {
            if (!string.IsNullOrEmpty(message))
            {
                var username = User.Identity?.Name;
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
                var habbit = new Habbit
                {
                    Message = message,
                    User = user,
                    RewardPoints = rewardPoints
                };
                _db.Habbits.Add(habbit);
                await _db.SaveChangesAsync();
                return Ok("Success added");
            }

            return NotFound("Message is empty");
        }


        [SwaggerOperation("Remove Habbit")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), 200)]
        [Route("Remove")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Remove(Guid idHabbit)
        {
            var username = User.Identity?.Name;
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            var habbit = await _db.Habbits.FirstOrDefaultAsync(d => d.User == user && d.Id == idHabbit);
            if (habbit != null)
            {
                _db.Habbits.Add(habbit);
                await _db.SaveChangesAsync();
                return Ok("Success added");
            }

            return NotFound("Not found habbit");
        }
    }
}