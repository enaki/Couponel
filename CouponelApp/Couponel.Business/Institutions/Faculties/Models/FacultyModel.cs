using System;

namespace Couponel.Business.Institutions.Faculties.Models
{
    public sealed class FacultyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UniversityId { get; set; }
        public Guid AddressId { get; set; }
    }
}
