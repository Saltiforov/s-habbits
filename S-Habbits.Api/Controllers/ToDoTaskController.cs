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
    public class ToDoTaskController : ControllerBase
    {
        private readonly SHabbitsDbContext _db;
        private readonly IMapper _mapper;

        public ToDoTaskController(SHabbitsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        [SwaggerOperation("Get All ToDoTasks")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ToDoTaskViewModel>), 200)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var username = User.Identity?.Name;
            var toDoTaskViewModels = _mapper.Map<IEnumerable<ToDoTaskViewModel>>(await
                _db.ToDoTasks.Where(d => d.User.Username == username).ToListAsync());
            return Ok(toDoTaskViewModels);
        }


        [SwaggerOperation("Add new ToDoTasks")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), 200)]
        [HttpPost]
        [Route("Add")]
        [Authorize]
        public async Task<IActionResult> Add(string message)
        {
            var username = User.Identity?.Name;
            var user = await _db.Users.FirstOrDefaultAsync(d => d.Username == username);
            if (user != null)
            {
                var toDoTask = new ToDoTask
                {
                    Message = message,
                    IsChecked = false,
                    User = user
                };
                await _db.ToDoTasks.AddAsync(toDoTask);
                await _db.SaveChangesAsync();
                return Ok("Success created");
            }

            return NotFound("Not found User");
        }

        [SwaggerOperation("Remove ToDoTasks")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), 200)]
        [HttpDelete]
        [Route("Remove")]
        [Authorize]
        public async Task<IActionResult> Remove(Guid idToDoTask)
        {
            var username = User.Identity?.Name;
            var user = await _db.Users.FirstOrDefaultAsync(d => d.Username == username);
            if (user != null)
            {
                var toDoTask = await _db.ToDoTasks.FirstOrDefaultAsync(d => d.Id == idToDoTask && d.User == user);
                if (toDoTask == null)
                {
                    _db.ToDoTasks.Remove(toDoTask);
                    await _db.SaveChangesAsync();
                    return Ok("Success deleted");
                }

                return NotFound("ToDoTask not found");
            }

            return NotFound("Not found User");
        }
    }
}