using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CouponelServices.Entities
{
    public sealed class University: Entity
    {
        public University(string name, string email, string phoneNumber)
        {
            Name = name;
            Addresses = new List<Address>();
            Email = email;
            PhoneNumber = phoneNumber;
            Faculties = new List<Faculty>();
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
        
        [Required]
        public ICollection<Address> Addresses { get; private set; }

        #endregion
    }
}
