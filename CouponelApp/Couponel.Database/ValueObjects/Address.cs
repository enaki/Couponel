using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Couponel.Entities.Institutions
{
    public sealed class Address: ValueObject
    {
        private Address() { }
        public Address(string country, string city, string street, string number)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
        }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }

        public void Update(string country, string city, string street, string number)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Country;
            yield return Number;
        }
    }
}
