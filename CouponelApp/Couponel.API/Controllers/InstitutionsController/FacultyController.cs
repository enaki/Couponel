using System;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Faculties.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.InstitutionsController
{
    [Route("api/universities/{universityId}/faculties")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFacultyService _facultyService;


        public FacultyController(ILogger<HomeController> logger, IFacultyService facultyService)
        {
            _logger = logger;
            _facultyService = facultyService;
        }

        [HttpGet("{facultyId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid facultyId)
        {
            var result = await _facultyService.GetByIdWithAddressStudentsAndUser(facultyId);
            Console.WriteLine(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUniversityId([FromRoute] Guid universityId)
        {
            var result = await _facultyService.GetAllByUniversityId(universityId);
            Console.WriteLine(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute]Guid universityId, [FromBody] CreateFacultyModel model)
        {
            model.UniversityId = universityId;
            var result = await _facultyService.Add(model);

            return Created(result.Id.ToString(), null);
        }
        [HttpPatch("{facultyId}")]
        public async Task<IActionResult> Update([FromRoute] Guid facultyId, [FromBody] UpdateFacultyModel model)
        {
            model.Id = facultyId;
            await _facultyService.Update(model);
            return NoContent();
        }

        [HttpDelete("{facultyId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid facultyId)
        {
            await _facultyService.Delete(facultyId);

            return NoContent();
        }
    }
}
