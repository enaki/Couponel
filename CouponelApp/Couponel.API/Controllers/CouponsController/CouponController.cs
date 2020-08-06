using System;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.Business.Coupons.Coupons.Models.SearchModels;
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
            var result = await _couponService.GetById(couponId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SearchModel model)
        {
            var coupons = await _couponService.GetBySearchModel(model);
            return Ok(coupons);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCouponModel model)
        {
            var result = await _couponService.Add(model);

            return Created(result.Id.ToString(), null);
        }

        [Route("{couponId}")]
        [HttpPatch]
        public async Task<IActionResult> Update([FromRoute] Guid couponId, UpdateCouponModel model)
        {
            await _couponService.Update(couponId, model);
            return NoContent();
        }

        [Route("{couponId}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid couponId)
        {
            await _couponService.Delete(couponId);
            return NoContent();
        }
    }
}
