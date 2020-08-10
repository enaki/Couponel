using System;
using System.ComponentModel.DataAnnotations;

namespace Couponel.Entities.Coupons
{
    public static class RedeemedCouponStatus
    {
        public const string Valid = "NotUsed";
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
