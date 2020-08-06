using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Couponel.Entities.Coupons
{
    public static class RedeemedCouponStatus
    {
        public const string NotUsed = "NotUsed";
        public const string Used = "Used";
        public const string Expired = "Expired";
    }

    public class RedeemedCoupon : Entity
    {
        public RedeemedCoupon(string status, Guid couponId)
        {
            Status = status;
            CouponId = couponId;
            RedeemedDate = DateTime.Now;
        }
        [Required]
        public DateTime RedeemedDate { get; private set; }
        [Required]
        public string Status { get; private set; }
        public void UpdateStatus(string status)
        {
            Status = status;
        }
        public Guid CouponId { get; private set; }
        public Coupon Coupon { get; private set; }
    }
}
