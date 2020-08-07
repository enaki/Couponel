using Couponel.Entities.ValueObjects;

namespace Couponel.Business.Identities.Users.Models
{
    public sealed class UpdateUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
