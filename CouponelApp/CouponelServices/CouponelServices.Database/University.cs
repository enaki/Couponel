using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CouponelServices.Entities
{
    public sealed class University: Entity
    {
        public University(string name, string address, string email, string phoneNumber)
        {
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;

        }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string Address { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }

    }
}
