using Couponel.Entities.Institutions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Couponel.Entities.Identities.UserTypes
{
    public sealed class Admin : Person
    {
        public Admin(string firstName, string lastName, string email, string phoneNumber)
            : base(firstName, lastName, email, phoneNumber)
        {
        }

        #region Database Relations

        [ForeignKey("Address")]
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }


        [ForeignKey("User")]
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        #endregion
    }
}
