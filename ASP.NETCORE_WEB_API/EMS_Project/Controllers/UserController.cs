using EMS_Project.Application.DTO_s.EventDTO_s;
using EMS_Project.Application.Interfaces;
using EMS_Project.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EMS_Project.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // Admin can see him/her self data
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public  async Task<IActionResult> GetUser()  
        {

            var UserId = User.GetUserId();
            var result = await userService.GetUserService(UserId);
            return Ok(result);

        }

        // Admin can see all user data
        [EnableRateLimiting("itokenBucketPolicy")]
        [Authorize(Roles = "Admin")]
        [HttpGet("AllUsers")]
        public  async Task<IActionResult> GetUsers()  
        {
            var result = await userService.GetUsersService();
            return Ok(result);

        }

        // Admin,Organization and User can register to the event 
        [EnableRateLimiting("itokenBucketPolicy")]
        [Authorize(Roles = "Admin,Organization,User")]
        [HttpPost("RegiserToEvent/{eventId:int}")]
        public  async Task<IActionResult> RegiserToEvent(int eventId)  
        {
            var UserId = User.GetUserId();
            var result = await userService.RegiserToEventService(UserId,eventId);
            return Ok(result);

        }

        // Admin,Organization and User can UnEnrolledT to the event
        [Authorize(Roles = "Admin,Organization,User")]
        [HttpPatch("UnEnrolledToEvent/{eventId:int}")]
        public  async Task<IActionResult> UnEnrolledToEvent(int eventId)
        {
            var UserId = User.GetUserId();
            var result = await userService.UnEnrolledToEvent(UserId, eventId);
            return Ok(result);

        }

        // Only Admin can Cancell the event
        [Authorize(Roles = "Admin")]
        [HttpPatch("CancellEvent/{eventId:int}")]
        public  async Task<IActionResult> CancellEvent(int eventId)
        {
            var result = await userService.CancelleEvent(eventId);
            return Ok(result);

        }
       
    }
}
