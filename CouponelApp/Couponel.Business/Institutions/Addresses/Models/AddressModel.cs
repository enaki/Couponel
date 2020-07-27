using System;

namespace Couponel.Business.Institutions.Addresses.Models
{
    public sealed class AddressModel
    {
        public Guid Id { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}
