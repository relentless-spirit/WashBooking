using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WashBooking.Application.DTOs.AuthDTO.LoginDTO;
using WashBooking.Application.DTOs.AuthDTO.LogoutDTO;
using WashBooking.Application.DTOs.AuthDTO.RefreshTokenDTO;
using WashBooking.Application.DTOs.AuthDTO.RegisterDTO;
using WashBooking.Application.Interfaces.Auth;

namespace WashBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (result.IsFailure)
            {
                if (result.Error.Code.Contains("Duplicate"))
                {
                    return Conflict(result.Error);
                }
                else if (result.Error.Code.Contains("Validation"))
                {
                    return UnprocessableEntity(result.Errors);
                }
                return BadRequest(result.Error);
            }

            return Ok("Đăng kí tài khoản thành công!");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            if (result.IsFailure)
            {
                if (result.Error.Code.Contains("Validation"))
                {
                    return UnprocessableEntity(result.Errors);
                }
                else if (result.Error.Code.Contains("InvalidCredentials"))
                {
                    return Unauthorized(result.Error);
                }
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var result = await _authService.LogoutAsync(request);
            if (result.IsFailure)
            {
                if (result.Error.Code.Contains("Validation"))
                {
                    return UnprocessableEntity(result.Errors);
                }
                else if (result.Error.Code.Contains("NotFound"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }
            return Ok("Đăng xuất thành công!");
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _authService.RefreshTokenAsync(request);
            if (result.IsFailure)
            {
                if (result.Error.Code.Contains("Validation"))
                {
                    return UnprocessableEntity(result.Errors);
                }
                else if (result.Error.Code.Contains("Invalid"))
                {
                    return Unauthorized(result.Error);
                }
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
    }
}
