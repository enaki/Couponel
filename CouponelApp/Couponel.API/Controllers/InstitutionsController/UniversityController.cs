using System;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Business.Institutions.Universities.Services.Interfaces;
using Couponel.Entities.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.InstitutionsController
{
    [Route("api/universities")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;
        private readonly ILogger<UniversityController> _logger;

        public UniversityController(ILogger<UniversityController> logger, IUniversityService universityService)
        {
            _logger = logger;
            _universityService = universityService;
        }

        [Authorize]
        [HttpGet("{universityId}")]
        public async Task<IActionResult> GetByIdWithAddress([FromRoute] Guid universityId)
        {
            var result = await _universityService.GetByIdWithAddressAndFaculties(universityId);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _universityService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Add([FromBody] CreateUniversityModel model)
        {

            var result = await _universityService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPatch("{universityId}")]
        public async Task<IActionResult> Update([FromRoute]Guid universityId, UpdateUniversityModel model)
        {
            await _universityService.Update(universityId, model);
            return NoContent();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{universityId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid universityId)
        {
            await _universityService.Delete(universityId);

            return NoContent();
        }
    }
}
