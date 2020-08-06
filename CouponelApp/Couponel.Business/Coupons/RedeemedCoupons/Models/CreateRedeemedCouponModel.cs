using System;
using Couponel.Entities.Coupons;

namespace Couponel.Business.Coupons.Coupons.Models.RedeemedCouponsModels
{
    public sealed class CreateRedeemedCouponModel
    {
        public string Status { get; set; }
        public Guid CouponId { get; set; }
    }
}
