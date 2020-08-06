using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.Coupons;

namespace Couponel.Business.Coupons.RedeemedCoupons.Models
{
    public sealed class  ListRedeemedCouponModel
    {
        public string Status { get; set; }
        public DateTime RedeemedDate { get; set; }
        public Coupon Coupon { get; set; }
        public Guid CouponId { get; set; }
    }
}
