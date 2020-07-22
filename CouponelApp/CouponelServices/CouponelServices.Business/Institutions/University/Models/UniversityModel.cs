using System;

namespace CouponelServices.Business.Institutions.University.Models
{
    public sealed class UniversityModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid AddressId { get; private set; }
    }
}
