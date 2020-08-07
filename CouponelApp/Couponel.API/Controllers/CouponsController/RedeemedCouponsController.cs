using System;
using System.Threading.Tasks;
using Couponel.API.Controllers.IdentitiesController;
using Couponel.Business.Coupons.RedeemedCoupons.Services.Interfaces;
using Couponel.Entities.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.CouponsController
{
    [Authorize(Roles = Role.Student)]
    [Route("api/redeemedCoupons")]
    [ApiController]
    public class RedeemedCouponsController : ControllerBase
    {
        private readonly IRedeemedCouponsService _redeemedCouponsService;
        private readonly ILogger<UserController> _logger;

        public RedeemedCouponsController(ILogger<UserController> logger, IRedeemedCouponsService redeemedCouponsService)
        {
            _logger = logger;
            _redeemedCouponsService = redeemedCouponsService;
        }
        
        [HttpGet("{redeemedCouponId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid redeemedCouponId)
        {
            var result= await _redeemedCouponsService.Get(redeemedCouponId);
            return Ok(result);
        }

        [HttpPost("{couponId}")]
        public async Task<IActionResult> Add([FromRoute] Guid couponId)
        {
            var result = await _redeemedCouponsService.Add(couponId);
            return Created(result.Id.ToString(), null);
        }

        [HttpPatch("{redeemedCouponId}")]
        public async Task<IActionResult> Update([FromRoute] Guid redeemedCouponId, string newStatus)
        {
            await _redeemedCouponsService.UpdateStatus(redeemedCouponId, newStatus);
            return NoContent();
        }

        [HttpDelete("{redeemedCouponId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid redeemedCouponId)
        {
            await _redeemedCouponsService.Delete(redeemedCouponId);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _redeemedCouponsService.GetAll();
            return Ok(result);
        }
    }
}