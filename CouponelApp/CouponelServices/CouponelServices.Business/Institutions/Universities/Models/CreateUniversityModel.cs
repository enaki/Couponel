using System;

namespace CouponelServices.Business.Institutions.Universities.Models
{
    public sealed class CreateUniversityModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid AddressId { get; private set; }
    }
}
