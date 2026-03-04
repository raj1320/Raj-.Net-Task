using EMS_Project.Application.DTO_s.UserDto_s;
using EMS_Project.Application.Interfaces;
using EMS_Project.Application.Services;
using EMS_Project.CustomException;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Project.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;

        public AuthController(IAuthService authService)
        {
              _AuthService = authService;
        }

        // Register Admin, Organization , User.. etc
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult?> RegisterAsync(RegisterUserDto userDTO)
        {
            var Response = await _AuthService.Register(userDTO);       
            return Ok(Response);
        }

        // Login Admin, Organization , User.. etc
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginDTO)
        {
            var Response = await _AuthService.Login(loginDTO);
            return Ok(Response);
        }

        // End point for get accesstoken via refreshtoken 
        [HttpPost("Get-AccessToken")]
        public async Task<ActionResult<ResponseTokenDto?>> RefreshTokenRequest(RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            var Response = await _AuthService.RefreshTokenRequestService(refreshTokenRequestDTO);
            return Ok(Response);
        }

    }
}


