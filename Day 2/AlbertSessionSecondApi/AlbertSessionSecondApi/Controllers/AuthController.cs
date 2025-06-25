using AlbertSessionSecondApi.DTO;
using AlbertSessionSecondApi.Helpers;
using AlbertSessionSecondApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlbertSessionSecondApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AlbertSessionSecondContext _context;
        public AuthController(AlbertSessionSecondContext context)
        {
            _context = context;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (string.IsNullOrEmpty(request.username) || string.IsNullOrEmpty(request.password))
            {
                return BadRequest(new LoginResponseDto { 
                    Success = false,
                    Message = "Username and password cannot be empty.",
                    userId = null
                });
            }
            var user = _context.Users.FirstOrDefault(u => u.Username == request.username);
            if (user == null)
            {
                return NotFound(new LoginResponseDto
                {
                    Message = "User not found.",
                    Success = false,
                    userId = null,
                });
            }
            string hashedPassword = user.PasswordHash;
            int userId = user.UserId;

            if(!PasswordHelper.verifyPassword(request.password
                , hashedPassword))
            {
                return Unauthorized(new LoginResponseDto
                {
                    Message = "Invalid password.",
                    Success = false,
                    userId = null,
                });
            }
            else
            {
                return Ok(new LoginResponseDto
                {
                    Message = "Login successful.",
                    Success = true,
                    userId = userId
                });
            }
            
        }
       
    }
}
