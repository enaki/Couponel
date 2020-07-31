using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Couponel.Entities.Coupons
{
    public class RedeemedCoupon : Entity
    {
        public RedeemedCoupon(string status)
        {
            Status = status;
        }
        [Required]
        public DateTime ReedemedDate { get; private set; }
        [Required]
        public string Status { get; private set; }
        public void Update(string status)
        {
            Status = status;
        }
        #region Database Relations
        [Required]
        [ForeignKey("Coupon")]
        public Guid CouponId { get; private set; }
        [Required]
        public Coupon Coupon { get; private set; }
        #endregion
    }
}
