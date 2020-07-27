using System.ComponentModel.DataAnnotations;

namespace Couponel.Entities
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
