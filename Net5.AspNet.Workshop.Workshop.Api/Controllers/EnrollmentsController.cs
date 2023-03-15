using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5.AspNet.Workshop.Infrastructure.Dtos;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters;
using Net5.AspNet.Workshop.Workshop.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IWorkshopService _workshopService;

        public EnrollmentsController(
            IWorkshopService workshopService
        )
        {
            _workshopService = workshopService;
        }

        [HttpGet()]
        public IActionResult ListEnrollments([FromQuery]EnrollmentFilter enrollmentFilter)
        {
            return Ok(_workshopService.ListEnrollments(enrollmentFilter));
        }

        
        [HttpPost("ChangeEnrollmentStates")]
        public IActionResult ChangeEnrollmentStates(ChangeEnrollmentStatesFilter changeEnrollmentStatesFilter)
        {
            return Ok(_workshopService.ChangeEnrollmentStates(changeEnrollmentStatesFilter));
        }

        [HttpPost()]
        public IActionResult InsertEnrollment(EnrollmentDto enrollment)
        {
            return Ok(_workshopService.InsertEnrollment(enrollment));
        }
    }
}
