using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [SwaggerOperation("Get All ToDoTasks")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ToDoTaskViewModel>), 200)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add(string message)
        {
            string username = User.Identity?.Name;
            IEnumerable<ToDoTaskViewModel> toDoTaskViewModels = _mapper.Map<IEnumerable<ToDoTaskViewModel>>(
                _db.ToDoTasks.Where(d => d.User.Username == username).ToList());
            return Ok();
        }
    }
}