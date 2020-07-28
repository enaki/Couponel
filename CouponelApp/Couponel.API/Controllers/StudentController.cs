using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Business.Identities.Students.Models;
using Couponel.Business.Identities.Students.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers
{
    [Route("student")]
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
        public async Task<IActionResult> GetById([FromRoute] Guid studentId)
        {
            var result = await _studentService.GetById(studentId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStudentModel model)
        {
            var result = await _studentService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid studentId)
        {
            await _studentService.Delete(studentId);

            return NoContent();
        }
    }
}
