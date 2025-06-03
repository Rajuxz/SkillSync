using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Dtos;
using SkillSync.Models;
using SkillSync.Services.Interfaces;
using System.Net.NetworkInformation;

namespace SkillSync.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;
        public readonly IJwtService _jwtService;   
        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(new {message="Provide all the data!"});
            }
            bool isRegistered = await _authService.RegisterUser(registerDto);
            if (!isRegistered) {
                return BadRequest(new { message = "Opps! Couldn't Register!" });
            }

            string token = _jwtService.GenerateToken(registerDto.Email);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(30),
            };
            Response.Cookies.Append("skillSyncToken", token,cookieOptions);
            return Ok(new { message = "Registered Successfully" });

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Please fill all the fields" });
            }

            bool isAutorized = await _authService.Login(loginDto);
            if (!isAutorized) {
                return BadRequest(new { message = "Unable to login!" });
            }

            string token = _jwtService.GenerateToken(loginDto.Email, "User");
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(30),
            };
            Response.Cookies.Append("Jwt", token, cookieOptions);
            return Ok(new { message = "Account Created Successfully!" });
        }

        [HttpGet("check")]
        public IActionResult CheckUser() 
        {
            return Ok(new {message="Everything Ok"});   
        }
    }
}
