using System;
using System.Threading.Tasks;
using Couponel.Business.Identities.Admins.Models;
using Couponel.Business.Identities.Admins.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.IdentitiesController
{
    [Route("admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminService _adminService;

        public AdminController(ILogger<HomeController> logger, IAdminService adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }

        [HttpGet("{adminId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid adminId)
        {
            var result = await _adminService.GetById(adminId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAdminModel model)
        {
            var result = await _adminService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{adminId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid adminId)
        {
            await _adminService.Delete(adminId);

            return NoContent();
        }
    }
}
