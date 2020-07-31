using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Couponel.Entities.Coupons;
using Couponel.Entities.Institutions;

namespace Couponel.Entities.Identities.UserTypes
{
    public sealed class Student : Person
    {
        public Student(string firstName, string lastName, string email, string phoneNumber, Guid addressId) :
            base(firstName, lastName, email, phoneNumber)
        {
            AddressId = addressId;
            RedeemedCoupons = new List<RedeemedCoupon>();
        }

        public ICollection<RedeemedCoupon> RedeemedCoupons { get; private set; }

        #region Database Relations

        [ForeignKey("Address")]
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }


        [ForeignKey("User")]
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        #endregion

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
