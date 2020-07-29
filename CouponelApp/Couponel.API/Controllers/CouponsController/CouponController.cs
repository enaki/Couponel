using System;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Business.Coupons.Coupons.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.CouponsController
{
    [Route("api/v1/coupons")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICouponService _couponService;

        public CouponController(ILogger<HomeController> logger, ICouponService couponService)
        {
            _logger = logger;
            _couponService = couponService;
        }

        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid couponId)
        {
            var result = await _couponService.GetById(couponId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCouponModel model)
        {
            var result = await _couponService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{couponId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid couponId)
        {
            await _couponService.Delete(couponId);

            return NoContent();
        }
    }
}
