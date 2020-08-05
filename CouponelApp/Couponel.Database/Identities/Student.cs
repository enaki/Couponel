using System;
using System.Collections.Generic;
using System.Linq;
using Couponel.Entities.Coupons;

namespace Couponel.Entities.Identities
{
    public sealed class Student : Entity
    {
        public Student()
            : base()
        {
            RedeemedCoupons = new List<RedeemedCoupon>();
        }
        public Student(Guid id):base(id)
        {
            RedeemedCoupons = new List<RedeemedCoupon>();
        }
        public User User { get; private set; }

        public ICollection<RedeemedCoupon> RedeemedCoupons { get; private set; }
        public void AddRedeemedCoupon(RedeemedCoupon redeemedCoupon)
        {
            RedeemedCoupons.Add(redeemedCoupon);
        }

        public void RemoveRedeemedCoupon(Guid redeemedCouponId)
        {
            var redeemedCoupon = this.RedeemedCoupons.FirstOrDefault(rc => rc.Id == redeemedCouponId);
            if (redeemedCoupon != null)
            {
                RedeemedCoupons.Remove(redeemedCoupon);
            }
        }
    }
}
