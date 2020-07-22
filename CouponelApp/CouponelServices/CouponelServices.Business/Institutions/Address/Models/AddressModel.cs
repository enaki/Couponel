using System;

namespace CouponelServices.Business.Institutions.Address.Models
{
    public sealed class AddressModel
    {
        public Guid Id { get; private set; }

        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
    }
}
