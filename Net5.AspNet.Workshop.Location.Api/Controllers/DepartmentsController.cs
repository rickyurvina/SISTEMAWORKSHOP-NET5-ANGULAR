using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5.AspNet.Workshop.Location.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Location.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public DepartmentsController(
            ILocationService locationService
        )
        {
            _locationService = locationService;
        }
        [AllowAnonymous]
        [HttpGet()]
        public IActionResult ListDepartments()
        {
            return Ok(_locationService.ListDepartments());
        }
    }
}
