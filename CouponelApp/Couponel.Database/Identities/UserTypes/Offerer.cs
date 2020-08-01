using Couponel.Entities.Coupons;
using Couponel.Entities.Institutions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Couponel.Entities.Identities.UserTypes
{
    public sealed class Offerer : Person
    {
        public Offerer(string firstName, string lastName, string phoneNumber)
            : base(firstName, lastName, phoneNumber)
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

        #endregion
    }
}
