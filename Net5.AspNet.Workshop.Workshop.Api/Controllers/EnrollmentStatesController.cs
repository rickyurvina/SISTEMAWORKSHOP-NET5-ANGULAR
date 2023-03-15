using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class EnrollmentStatesController : ControllerBase
    {
        private readonly IWorkshopService _workshopService;

        public EnrollmentStatesController(
            IWorkshopService workshopService
        )
        {
            _workshopService = workshopService;
        }

        [HttpGet()]
        public IActionResult ListEnrollmentStates([FromQuery] EnrollmentStateFilter EnrollmentStateFilter)
        {
            return Ok(_workshopService.ListEnrollmentStates(EnrollmentStateFilter));
        }
    }
}
