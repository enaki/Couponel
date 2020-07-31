using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Entities.Coupons
{
    public class RedeemedCoupon : Entity
    {
        public DateTime ReedemedDate { get; private set; }
        public string Status { get; private set; }
    }
}
