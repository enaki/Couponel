using System;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Addresses.Models;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Business.Institutions.Universities.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.InstitutionsController
{
    [Route("api/universities")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUniversityService _universityService;

        public UniversityController(ILogger<HomeController> logger, IUniversityService universityService)
        {
            _logger = logger;
            _universityService = universityService;
        }

        [HttpGet("{universityId}")]
        public async Task<IActionResult> GetByIdWithAddress([FromRoute] Guid universityId)
        {
            var result = await _universityService.GetByIdWithAddressAndFaculties(universityId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _universityService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUniversityModel model)
        {

            var result = await _universityService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [HttpPatch("{universityId}")]
        public async Task<IActionResult> Update([FromRoute]Guid universityId, UpdateUniversityModel model)
        {
            await _universityService.Update(universityId, model);
            return NoContent();
        }

        [HttpDelete("{universityId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid universityId)
        {
            await _universityService.Delete(universityId);

            return NoContent();
        }
    }
}
