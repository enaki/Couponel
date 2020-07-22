using System;

namespace CouponelServices.Business.Institutions.Faculty.Models
{
    public sealed class CreateFacultyModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid UniversityId { get; private set; }
        public Guid AddressId { get; private set; }
    }
}
