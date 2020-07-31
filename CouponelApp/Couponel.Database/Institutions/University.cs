using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Couponel.Entities.Institutions
{
    public sealed class University : Entity
    {
        public University(string name, string email, string phoneNumber, Guid addressId)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Faculties = new List<Faculty>();
            AddressId = addressId;
        }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        public string PhoneNumber { get; private set; }


        #region Database Relations

        [Required]
        public ICollection<Faculty> Faculties { get; private set; }

        [ForeignKey("Address")]
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }

        #endregion
    }
}
