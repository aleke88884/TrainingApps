using AlbertSession2API.DTO;
using AlbertSession2API.Helpers;
using AlbertSession2API.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AlbertSession2API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AlbertTwoContext _context;

        public AuthController(AlbertTwoContext context)
        {
            _context = context;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new LoginResponse
                {
                    Success = false,
                    Message = "Username and password cannot be empty."
                });
            }
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if(user == null)
            {
                return NotFound(new LoginResponse
                {
                    Success = false,
                    Message = "User was not found!."
                });
            }

            string hashedPassword = user.PasswordHash;
            int userId = user.UserId;

            if (!PasswordHelper.verifyPassword(request.Password, hashedPassword))
            {
                return Unauthorized(new LoginResponse
                {
                    Success = false,
                    Message = "Invalid password."
                });
            }
            else
            {
                return Ok(new LoginResponse
                {
                    Success = true,
                    Message = "Login successful.",
                    UserId = userId
                });
            }


        }


    }
}
