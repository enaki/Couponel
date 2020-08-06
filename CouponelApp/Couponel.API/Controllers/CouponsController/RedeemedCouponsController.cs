using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.API.Controllers.IdentitiesController;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Business.Coupons.Coupons.Models.RedeemedCouponsModels;
using Couponel.Business.Coupons.RedeemedCoupons.Services.Interfaces;
using Couponel.Business.Identities.Users.Services.Interfaces;
using Couponel.Entities.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.CouponsController
{
    [Route("api/redeemedCoupons")]
    [ApiController]
    public class RedeemedCouponsController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRedeemedCouponsService _redeemedCouponsService;

        public RedeemedCouponsController(ILogger<UserController> logger, IRedeemedCouponsService redeemedCouponsService)
        {
            _logger = logger;
            _redeemedCouponsService = redeemedCouponsService;
        }

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

        [Authorize(Roles = Role.Student)]
        [HttpPost("{couponId}")]
        public async Task<IActionResult> Add([FromRoute] Guid couponId)
        {
            var result = await _redeemedCouponsService.Add(couponId);
            return Created(result.Id.ToString(), null);
        }

        [HttpPatch("{redeemedCouponId}")]
        public async Task<IActionResult> Update([FromRoute] Guid studentId,[FromRoute] Guid redeemedCouponId, [FromBody] UpdateRedeemedCouponModel model)
        {
            throw new NotImplementedException();
        }
    }
}