using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5.AspNet.Workshop.Infrastructure.Dtos;
using Net5.AspNet.Workshop.Workshop.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDatumController : ControllerBase
    {
        private readonly IWorkshopService _workshopService;

        public FileDatumController(
            IWorkshopService workshopService
        )
        {
            _workshopService = workshopService;
        }

        [AllowAnonymous]
        [HttpGet("{fileDataId}/GetFile")]
        public IActionResult GetFile(int fileDataId)
        {
            FileDatumDto file = _workshopService.GetFileDatumByFileDataId(fileDataId);
            return File(file.ByteArray, file.Type);
        }
    }
}
