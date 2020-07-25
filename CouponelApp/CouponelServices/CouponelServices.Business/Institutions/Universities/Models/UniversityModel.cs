using System;

namespace CouponelServices.Business.Institutions.Universities.Models
{
    public sealed class UniversityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid AddressId { get; set; }
    }
}
