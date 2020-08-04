using Couponel.Entities.Coupons;
using Couponel.Entities.Institutions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Couponel.Entities.Identities.UserTypes
{
    public sealed class Offerer : Entity
    {
        public Offerer()
            : base()
        {
            Coupons = new List<Coupon>();
        }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public ICollection<Coupon> Coupons { get; private set; }
        public void AddCoupon(Coupon coupon)
        {
            Coupons.Add(coupon);
        }
        public void RemoveCoupon(Guid couponId)
        {
            var coupon = this.Coupons.FirstOrDefault(rc => rc.Id == couponId);

            if (coupon != null)
            {
                Coupons.Remove(coupon);
            }
        }
    }
}
