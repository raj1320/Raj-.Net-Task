using ASP.NETCORE_WEB_API_Project1.Application.DTOs;
using ASP.NETCORE_WEB_API_Project1.Application.Interface;
using Microsoft.AspNetCore.Mvc;
namespace ASP.NETCORE_WEB_API_Project1.Controllers
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

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<ResponseDTO>?> RegisterAsync(UserDTO userDTO)
        {
            var Response = await _AuthService.Register(userDTO);

            if (Response == null) return NotFound("User already exsist!");

            return Ok(Response);
        }
       
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ResponseDTO>?> Login(LoginDTO loginDTO)
        {
            var Response = await _AuthService.Login(loginDTO);

            if (Response == null) return NotFound("Email or Password not match!");

            return Ok(Response);
        }


    }
}
