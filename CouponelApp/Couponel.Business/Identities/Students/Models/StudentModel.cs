using System;

namespace Couponel.Business.Identities.Students.Models
{
    public sealed class StudentModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid AddressId { get; set; }
    }
}
