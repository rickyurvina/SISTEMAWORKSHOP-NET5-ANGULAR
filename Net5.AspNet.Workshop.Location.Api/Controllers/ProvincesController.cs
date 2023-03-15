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
    [Route("api/Departments/{departmentId}/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public ProvincesController(
            ILocationService locationService
        )
        {
            _locationService = locationService;
        }
        [AllowAnonymous]
        [HttpGet()]
        public IActionResult ListProvinces(int departmentId)
        {
            return Ok(_locationService.ListProvinces(departmentId));
        }
    }
}
