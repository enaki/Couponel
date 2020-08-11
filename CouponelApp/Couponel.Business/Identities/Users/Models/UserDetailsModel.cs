using Couponel.Entities.ValueObjects;

namespace Couponel.Business.Identities.Users.Models
{
    public class UserDetailsModel:IUserDetailsModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public Address Address { get; set; }
    }
}
