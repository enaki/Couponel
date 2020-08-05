using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Business.Identities.Students.Services.Interfaces;
using Couponel.Business.Identities.Users.Models;
using Couponel.Business.Identities.Users.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.IdentitiesController
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUsersService _usersService;

        public UserController(ILogger<UserController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid userId)
        {
            var result = await _usersService.GetDetailsById(userId);
            return Ok(result);
        }

        [HttpPatch("{userId}")]
        public async Task<IActionResult> Update([FromRoute]Guid userId, [FromBody]UpdateUserModel model)
        {
            model.Id = userId;
            await _usersService.Update(model);
            return NoContent();
        }
    }
}