using Microsoft.AspNetCore.Mvc;
using SecureFlow.Application.Interfaces;
using SecureFlow.Application.DTOs;

namespace SecureFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(IUserService userService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var isValidUser = await _userService.ValidateUserAsync(request.Username, request.Password);
            if (!isValidUser)
            {
                return Unauthorized();
            }

            var role = await _userService.GetUserRoleAsync(request.Username);

            // Token da üreteceksen buraya eklenir
            var token = _jwtTokenGenerator.GenerateTokenAsync(request.Username, role);

            // return Ok(new { Username = request.Username, Role = role });
            return Ok(new { Token = token, Username = request.Username, Role = role });

        }
    }
}
