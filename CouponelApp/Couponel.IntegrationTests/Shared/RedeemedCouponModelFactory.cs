using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.Coupons;

namespace Couponel.IntegrationTests.Shared
{
    public static class RedeemedCouponModelFactory
    {
        public static RedeemedCoupon Default()
        {
            var offerer = UserRegisterModelFactory.getUserFactory("Offerer").getUser();
            var coupon = CouponModelFactory.Default();
            offerer.AddCoupon(coupon);
            return new RedeemedCoupon("Used",coupon.Id);
        }
    }
}
