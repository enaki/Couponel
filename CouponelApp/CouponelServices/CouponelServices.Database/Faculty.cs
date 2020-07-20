using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CouponelServices.Entities
{
    public sealed class Faculty: Entity
    {
        public Faculty(string name, string email, string phoneNumber)
        {
            Name = name;
            Addresses = new List<Address>();
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
        public ICollection<Address> Addresses { get; private set; }

        #endregion
    }
}
