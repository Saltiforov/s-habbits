using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S_Habbits.Data;
using S_Habbits.Shared;
using Swashbuckle.AspNetCore.Annotations;

namespace S_Habbits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private S_HabbitsDbContext _db;
        public AccountController(S_HabbitsDbContext db)
        {
            _db = db;
        }

        [SwaggerOperation("Register")]
        [SwaggerResponse((int) HttpStatusCode.OK)]
        [SwaggerResponse((int) HttpStatusCode.NotFound)]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(string email, string username, string password,string confirmPassword)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if(!IsValidMail(email))
                {
                    return Problem("Email is incorrect");
                }
                if (password != confirmPassword)
                {
                    return Problem("Password and confirm password do not match");
                }                
            }
            var emailIsExists = await _db.Users.AnyAsync(d => d.Email == email);
            var usernameIsExists = await _db.Users.AnyAsync(d => d.Username == username);
            if (emailIsExists)
            {
                return Problem("Email is exists");
            }
            if (usernameIsExists)
            {
                return Problem("Username is exists");
            }

            var user = new User()
            {
                Email = email,
                Username = username,
                Password = password.ToSha1(),
                Points = 0
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok("Success");
        }

        private bool IsValidMail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        [SwaggerOperation("Login")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // if (!IsValidUsernameAndPasswod(username, password))
            //     return BadRequest();
            var user = await GetUser(username, password.ToSha1());
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                //...
            }, "Cookies");

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await Request.HttpContext.SignInAsync("Cookies", claimsPrincipal);

            return NoContent();
        }
        private async Task<User> GetUser(string username, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
      
       [SwaggerOperation("Logout")]
       [SwaggerResponse((int)HttpStatusCode.OK)]
       [SwaggerResponse((int)HttpStatusCode.NotFound)]
       [HttpGet]
       [Route("Logout")]
       [Authorize]
       public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return NoContent();
        }
    }
}