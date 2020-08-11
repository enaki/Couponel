using System;
using System.Threading.Tasks;
using Couponel.Business.Identities.Users.Models;
using Couponel.Business.Identities.Users.Services.Interfaces;
using Couponel.Entities.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.IdentitiesController
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }
       
        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid userId)
        {
            var result = await _usersService.GetDetailsById(userId);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersService.GetAll();
            return Ok(result);
        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody]UpdateUserModel model)
        {
            await _usersService.Update(model);
            return NoContent();
        }

    }
}