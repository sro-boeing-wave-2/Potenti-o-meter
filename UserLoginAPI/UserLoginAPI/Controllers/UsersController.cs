using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLoginAPI.Models;
using UserLoginAPI.Services;

namespace UserLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersControllerService _service;

        private string globalToken;
        //private string globalTok = HttpContext.Request.Cookies["UserLoginAPItoken"];

        public UsersController(IUsersControllerService service)
        {
            _service = service;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return _service.GetUserService();
        }

        // GET: api/Users/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _service.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Users/abcd
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _service.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            if (EmailChanged(id, user.Email))
            {
                if (EmailExists(user.Email))
                {
                    return BadRequest(error: "The emailid already exists");
                }
            }

            string hashed = HashPassword(user.Password);
            user.Password = hashed;

            try
            {
                await _service.PutUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(EmailExists(user.Email))
            {
                return BadRequest(error: "The email id already Exists");
            }

            string hashed = HashPassword(user.Password);
            user.Password = hashed;

            await _service.PostUser(user);

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

		// POST: api/Users/Login
		[HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]Login user)
        {
            if (user == null)
            {
                return BadRequest("Invalid Request");
            }

            string tokenString = await _service.Login(user.Email, user.Password);
            if(tokenString == "Incorrect Password")
            {
                return BadRequest(error: "Incorrect Password");
            }
            else if (tokenString == null)
            {
                return Unauthorized();
            }
            else
            {
                CookieOptions cookie = new CookieOptions
                {
                    Expires = DateTime.Now.AddHours(2)
                };
                HttpContext.Response.Cookies.Append("UserLoginAPItoken", tokenString, cookie);
                globalToken = tokenString;
                return Ok(new { Token = tokenString });
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _service.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users/Login
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("UserLoginAPItoken");
            return Ok();
        }

        // POST: api/Users/Quiz
        [HttpGet("Quiz")]
        public IActionResult Quiz()
        {
            var token = HttpContext.Request.Cookies["UserLoginAPItoken"];
            var userid = _service.GetUserIDfromToken(token);
            return Ok(new { tokenstring = token,
                            id = userid});
        }

        private bool UserExists(int id)
        {
            return _service.UserExists(id);
        }

        private bool EmailExists(string email)
        {
            return _service.EmailExists(email);
        }

        private string HashPassword(string Password)
        {
            return _service.HashPassword(Password);
        }

        private bool EmailChanged(int id, string email)
        {

            return _service.EmailChanged(id, email);
        }
    }
}