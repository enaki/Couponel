using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Business.Coupons.Coupons.Models.RedeemedCouponsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Couponel.API.Controllers.CouponsController
{
    [Route("api/{userid}/students/{studentId}/redeemedCoupons")]
    [ApiController]
    public class RedeemedCouponsController : ControllerBase
    {
        [HttpGet("{redeemedCouponId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid redeemedCouponId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] Guid redeemedCouponId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid studentId,[FromRoute] Guid couponId, [FromBody] CreateRedeemedCouponModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPatch("{redeemedCouponId}")]
        public async Task<IActionResult> Update([FromRoute] Guid studentId,[FromRoute] Guid redeemedCouponId, [FromBody] UpdateRedeemedCouponModel model)
        {
            throw new NotImplementedException();
        }
    }
}