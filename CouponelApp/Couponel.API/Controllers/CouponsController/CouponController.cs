using System;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Business.Coupons.Coupons.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.CouponsController
{
    [Route("api/coupons")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ILogger<CouponController> _logger;
        private readonly ICouponService _couponService;

        public CouponController(ILogger<CouponController> logger, ICouponService couponService)
        {
            _logger = logger;
            _couponService = couponService;
        }

        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid couponId)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SearchModel model)
        {
            var coupons = await _couponService.GetBySearchModel(model);
            return Ok(coupons);

        }

        [Route("api/offerers/{offererId}/coupons")]
        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid offererId,[FromBody] CreateCouponModel model)
        {
            throw new NotImplementedException();

        }

        [Route("api/offerers/{offererId}/{couponId}")]
        [HttpPatch]
        public async Task<IActionResult> Update([FromRoute] Guid offererId,[FromRoute] Guid couponId, UpdateCouponModel model)
        {
            throw new NotImplementedException();

        }

        [Route("api/offerers/{offererId}/{couponId}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid offererId,[FromRoute] Guid couponId)
        {
            throw new NotImplementedException();

        }
    }
}
