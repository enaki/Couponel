using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CouponelServices.Entities
{
    public sealed class Faculty: Entity
    {
        public Faculty(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Students = new List<Student>();
        }
        [Required]
        public string Name { get; private set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        public string PhoneNumber { get; private set; }

        #region Database Relations

        [Required]
        public ICollection<Student> Students { get; private set; }

        [Required]
        [ForeignKey("Address")]
        public Guid AddressId { get; private set; }
        [Required]
        public Address Address { get; private set; }

        #endregion
    }
}
