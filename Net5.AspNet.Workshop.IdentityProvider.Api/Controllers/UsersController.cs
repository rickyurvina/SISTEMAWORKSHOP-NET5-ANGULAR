using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5.AspNet.Workshop.IdentityProvider.Api.Services;
using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public UsersController(
            ISecurityService securityService
        )
        {
            _securityService = securityService;
        }

        [HttpGet("{userName}")]
        public IActionResult GetUserByUserName(string userName)
        {
            return Ok(_securityService.GetUserByUserName(userName));
        }

        [AllowAnonymous]
        [HttpPost("{userName}/ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync(string userName,[FromBody]UserDto userDto)
        {
            return Ok(await _securityService.ForgotPasswordAsync(userName,userDto.Email));
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> InsertUserAsync(UserDto userDto)
        {
            return Ok(await _securityService.InsertUserAsync(userDto));
        }
    }
}
