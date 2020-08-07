using Couponel.Business.Identities.Users.Models;
using Couponel.Entities.ValueObjects;

namespace Couponel.Business.Identities.Students.Models
{
    public sealed class StudentDetailsModel:IUserDetailsModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FacultyName { get; set; }
        public string UniversityName { get; set; }
        public Address Address { get; set; }
    }
}
