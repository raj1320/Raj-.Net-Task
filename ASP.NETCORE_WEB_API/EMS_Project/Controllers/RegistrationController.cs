using EMS_Project.Application.Interfaces;
using EMS_Project.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Project.Controllers
{
    [Route("api/ViewRegistration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationServices registrationServices;
        public RegistrationController(IRegistrationServices registrationServices)
        {
           this.registrationServices = registrationServices;
        }

        //Admin can view the Registration
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ViewRegistration()
        {
            var result = await registrationServices.ShowRegistrationService();
            return Ok(result);
        }

        //Organization can view the Registration
        [HttpGet("organizationEvent")]
        [Authorize(Roles = "Organization")]
        public async Task<IActionResult> OrganizationViewRegistration()
        {
            int OrganizationId = User.GetUserId();
            var result = await registrationServices.ShowRegistrationForOrganizationService(OrganizationId);
            return Ok(result);
        }
    }
}
