using Couponel.Entities.Coupons;
using Couponel.Entities.Institutions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Couponel.Entities.Identities.UserTypes
{
    public sealed class Offerer : Person
    {
        public Offerer(string firstName, string lastName, string email, string phoneNumber)
            : base(firstName, lastName, email, phoneNumber)
        {
            Coupons = new List<Coupon>();
        }
        #region Database Relations

        [ForeignKey("Address")]
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }


        [ForeignKey("User")]
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

        #endregion
    }
}
