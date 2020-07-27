using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Business.Institutions.Universities.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers
{
    [Route("[controller]")]
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
        public async Task<IActionResult> GetById([FromRoute] Guid universityId)
        {
            var result = await _universityService.GetById(universityId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUniversityModel model)
        {
            var result = await _universityService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{universityId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid universityId)
        {
            await _universityService.Delete(universityId);

            return NoContent();
        }
    }
}
