using System;

namespace CouponelServices.Business.Institutions.Faculties.Models
{
    public sealed class FacultyModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid UniversityId { get; private set; }
        public Guid AddressId { get; private set; }
    }
}
