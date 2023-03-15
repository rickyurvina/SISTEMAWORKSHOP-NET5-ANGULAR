
using Microsoft.AspNetCore.Authorization;
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
    public class InstructorsController : ControllerBase
    {
        private readonly IWorkshopService _workshopService;

        public InstructorsController(
            IWorkshopService workshopService
        )
        {
            _workshopService = workshopService;
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult ListInstructors([FromQuery] InstructorFilter instructorFilter)
        {
            return Ok(_workshopService.ListInstructors(instructorFilter));
        }
    }
}
