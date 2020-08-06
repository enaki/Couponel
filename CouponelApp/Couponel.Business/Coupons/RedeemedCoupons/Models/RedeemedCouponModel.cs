using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.Coupons;

namespace Couponel.Business.Coupons.RedeemedCoupons.Models
{
    public sealed class RedeemedCouponModel
    {
        public string Status { get; set; }
        public Guid Id { get; set; }
        public Coupon Coupon { get; set; }
    }
}
