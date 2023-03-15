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
    [Route("api/Provinces/{provinceId}/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public DistrictsController(
            ILocationService locationService
        )
        {
            _locationService = locationService;
        }
        [AllowAnonymous]
        [HttpGet()]
        public IActionResult ListDistricts(int provinceId)
        {
            return Ok(_locationService.ListDistricts(provinceId));
        }
    }
}
