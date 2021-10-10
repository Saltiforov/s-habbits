using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S_Habbits.Data;
using S_Habbits.Shared.ViewModel;
using Swashbuckle.AspNetCore.Annotations;

namespace S_Habbits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private S_HabbitsDbContext _db;
        private IMapper _mapper;
        public ToDoTaskController(S_HabbitsDbContext db, IMapper mapper)
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
            string username = User.Identity?.Name;
            IEnumerable<ToDoTaskViewModel> toDoTaskViewModels = _mapper.Map<IEnumerable<ToDoTaskViewModel>>(
                _db.ToDoTasks.Where(d => d.User.Username == username).ToList());
            return Ok();
        }
        
        
        [SwaggerOperation("Add new ToDoTasks")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), 200)]
        [HttpPost]
        [Route("Add")]
        [Authorize]
        public async Task<IActionResult> Add(string message)
        {
            string username = User.Identity?.Name;
            var user = await _db.Users.FirstOrDefaultAsync(d => d.Username == username);
            if (user != null)
            {
                var toDoTask = new ToDoTask()
                {
                    Message = message,
                    IsChecked = false,
                    User =  user,
                };
                return Ok("Success created");
            }
            else
            {
                return NotFound("Not found User");
            }
        }
        
        [SwaggerOperation("Remove ToDoTasks")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), 200)]
        [HttpDelete]
        [Route("Remove")]
        [Authorize]
        public async Task<IActionResult> Remove(Guid idToDoTask)
        {
            string username = User.Identity?.Name;
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
                else
                {
                    return NotFound("ToDoTask not found");
                }
            }
            else
            {
                return NotFound("Not found User");
            }
        }
    }
}