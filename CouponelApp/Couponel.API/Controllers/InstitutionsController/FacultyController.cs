using System;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Faculties.Services.Interfaces;
using Couponel.Entities.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.InstitutionsController
{
    namespace Couponel.API.Controllers.InstitutionsController
    {
        
        [ApiController]
        [Route("api/universities/{universityId}/faculties")]
        public class FacultyController : ControllerBase
        {
            private readonly IFacultyService _facultyService;
            private readonly ILogger<FacultyController> _logger;

            public FacultyController(ILogger<FacultyController> logger, IFacultyService facultyService)
            {
                _logger = logger;
                _facultyService = facultyService;
            }
            [Authorize]
            [HttpGet("{facultyId}")]
            public async Task<IActionResult> GetById([FromRoute] Guid universityId,[FromRoute] Guid facultyId)
            {
                var result = await _facultyService.GetByIdWithAddress(universityId, facultyId);
                return Ok(result);
            }
            
            [HttpGet]
            [AllowAnonymous]
            public async Task<IActionResult> ListAllByUniversityId([FromRoute] Guid universityId)
            {
                var result = await _facultyService.GetAllByUniversityId(universityId);
                Console.WriteLine(result);
                return Ok(result);
            }
            
            [HttpPost]
            [Authorize(Roles = Role.Admin)]
            public async Task<IActionResult> Add([FromRoute]Guid universityId, [FromBody] CreateFacultyModel model)
            {
                model.UniversityId = universityId;
                var result = await _facultyService.Add(model);

                return Created(result.Id.ToString(), null);
            }

            [HttpPatch("{facultyId}")]
            [Authorize(Roles = Role.Admin)]
            public async Task<IActionResult> Update([FromRoute] Guid universityId,[FromRoute] Guid facultyId, [FromBody] UpdateFacultyModel model)
            {
                model.Id = facultyId;
                model.UniversityId = universityId;
                await _facultyService.Update(model);
                return NoContent();
            }

            [HttpDelete("{facultyId}")]
            [Authorize(Roles = Role.Admin)]
            public async Task<IActionResult> Delete([FromRoute]Guid universityId,[FromRoute] Guid facultyId)
            {
                await _facultyService.Delete(universityId,facultyId);
                return NoContent();
            }
        }
    }
}