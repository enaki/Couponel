using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Addresses.Models;
using Couponel.Business.Institutions.Addresses.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAddressService _addressService;

        public AddressController(ILogger<HomeController> logger, IAddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid addressId)
        {
            var result = await _addressService.GetById(addressId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAddressModel model)
        {
            var result = await _addressService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid addressId)
        {
            await _addressService.Delete(addressId);

            return NoContent();
        }
    }
}
