using System;
using System.Threading.Tasks;
using Couponel.Business.Identities.Students.Models;
using Couponel.Business.Identities.Students.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.IdentitiesController
{
    [Route("api/universities/{universityId}/faculties/{facultyId}/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid universityId, [FromRoute] Guid facultyId, [FromRoute] Guid studentId)
        {
            var result = await _studentService.GetStudentDetailsById(universityId, facultyId, studentId);
            return Ok(result);
        }
    }
}
