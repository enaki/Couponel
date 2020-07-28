using System;
using System.ComponentModel.DataAnnotations.Schema;
using Couponel.Entities.Institutions;

namespace Couponel.Entities.Identities.UserTypes
{
    public sealed class Student: Person
    {
        public Student(string firstName, string lastName, string email, string phoneNumber) : 
            base(firstName, lastName, email, phoneNumber)
        {
        }

        #region Database Relations

        [ForeignKey("Address")]
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }

        #endregion
    }
}
