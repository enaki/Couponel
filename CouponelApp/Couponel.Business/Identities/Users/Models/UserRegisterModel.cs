using System;
using Couponel.Entities.Identities;
using Couponel.Entities.Institutions;
using Couponel.Entities.ValueObjects;

namespace Couponel.Business.Identities.Users.Models
{
    public sealed class UserRegisterModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role{ get; set; }
        public string PhoneNumber { get; set; }
        public Guid UniversityId { get; set; }
        public Guid FacultyId { get; set; }
        public Address Address { get; set; }
    }
}
