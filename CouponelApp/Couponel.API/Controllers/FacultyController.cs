using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Faculties.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers
{
    [Route("[controller]")]
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
            var result = await _facultyService.GetById(facultyId);
            Console.WriteLine(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFacultyModel model)
        {
            var result = await _facultyService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{facultyId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid facultyId)
        {
            await _facultyService.Delete(facultyId);

            return NoContent();
        }
    }
}
