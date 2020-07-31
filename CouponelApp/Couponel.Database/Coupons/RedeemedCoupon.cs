using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Couponel.Entities.Coupons
{
    public class RedeemedCoupon : Entity
    {
        [Required]
        public DateTime ReedemedDate { get; private set; }
        [Required]
        public string Status { get; private set; }
    }
}
