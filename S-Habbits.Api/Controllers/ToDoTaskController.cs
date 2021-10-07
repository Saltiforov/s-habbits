using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S_Habbits.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace S_Habbits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private S_HabbitsDbContext _db;

        public ToDoTaskController(S_HabbitsDbContext db)
        {
            _db = db;
        }


        [SwaggerOperation("GetAllToDoTasks")]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ToDoTask), 200)]
        [Route("/ToDoTasks")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}