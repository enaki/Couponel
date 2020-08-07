using System;
using Couponel.Entities.Coupons;

namespace Couponel.IntegrationTests.Shared
{
    public static class CouponModelFactory
    {
        public static Coupon Default()
        {
            return new Coupon("Cupon1","Electronice",new DateTime(2020,12,20,12,21,31), "Cel mai tare cupon");
        }
    }
}
