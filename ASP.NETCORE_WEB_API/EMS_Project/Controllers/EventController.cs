using EMS_Project.Application.DTO_s.EventDTO_s;
using EMS_Project.Application.Interfaces;
using EMS_Project.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EMS_Project.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        // Admin and Organization can create an event
        [EnableRateLimiting("itokenBucketPolicy")]
        [Authorize(Roles = "Admin,Organization")]
        [HttpPost()]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {

            var UserId = User.GetUserId();
            var result = await eventService.CreateEventService(UserId, createEventDto);
            return Ok(result);

        }

        // Admin and Organization can update All an event
        [Authorize(Roles = "Admin")]
        [HttpPatch("{eventId:int}")]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] UpdateEventDto updateEventDto)
        {
            var UserId = User.GetUserId();
            var result =await eventService.UpdateEventService(UserId,eventId,updateEventDto );
            return Ok(result);
        }

        // Organization can only update their own created an event
        [Authorize(Roles = "Organization")]
        [HttpPatch("ByOrganizer/{eventId:int}")]
        public async Task<IActionResult> UpdateEventByOrganizer(int eventId,[FromBody] UpdateEventDto updateEventDto)
        {
            var organizerId = User.GetUserId();
            var result =await eventService.UpdateByOrganizationService(organizerId, eventId,updateEventDto );
            return Ok(result);
        }

        // Admin only delete an event
        [Authorize(Roles = "Admin")]
        [HttpDelete("{eventId:int}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            await eventService.DeleteEventService(eventId);
            return NoContent();
        }

        // All can see an event by eventId
        [EnableRateLimiting("itokenBucketPolicy")]
        [Authorize(Roles = "Admin,Organization,User")]
        [HttpGet("{eventId:int}")]
        public async Task<IActionResult> ShowEvent(int eventId)
        {
            var result =await eventService.ShowEventService(eventId);
            return Ok(result);
        }

        // All can see all events
        [EnableRateLimiting("itokenBucketPolicy")]
        [Authorize(Roles = "Admin,Organization,User")]
        [HttpGet]
        public async Task<IActionResult> ShowAllEvent()
        {
            var result =await eventService.ShowEventsService();
            return Ok(result);
        }

    }
}


