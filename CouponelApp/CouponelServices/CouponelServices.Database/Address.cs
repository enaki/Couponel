using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CouponelServices.Entities
{
    public sealed class Address: Entity
    {
        public Address(string country, string city, string street, string number)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
        }

        [Required]
        public string Country { get; private set; }
        
        [Required]
        public string City { get; private set; }
        
        [Required]
        public string Street { get; private set; }
        
        [Required]
        public string Number { get; private set; }
    }
}
