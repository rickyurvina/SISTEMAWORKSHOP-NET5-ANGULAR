using Microsoft.AspNetCore.Authorization;
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
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopsController(
            IWorkshopService workshopService
        )
        {
            _workshopService = workshopService;
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult ListWorkshops([FromQuery]WorkshopFilter workshopFilter)
        {
            return Ok(_workshopService.ListWorkshops(workshopFilter));
        }

        [AllowAnonymous]
        [HttpGet("{workshopId}")]
        public IActionResult GetWorkshopByWorshopId(int workshopId)
        {
            return Ok(_workshopService.GetWorkshopByWorshopId(workshopId));
        }

        [HttpPost()]
        public IActionResult InsertWorkshop(WorkshopDto workshopDto)
        {
            return Ok(_workshopService.InsertWorkshop(workshopDto));
        }

        [HttpPut("{workshopId}")]
        public IActionResult UpdateWorkshop(int workshopId,[FromBody] WorkshopDto workshopDto)
        {
            workshopDto.WorkshopId = workshopId;
            return Ok(_workshopService.UpdateWorkshop(workshopDto));
        }

        [HttpDelete("{workshopId}")]
        public IActionResult DeleteWorkshop(int workshopId)
        {            
            return Ok(_workshopService.DeleteWorkshop(workshopId));
        }
    }
}
