using System.ComponentModel.DataAnnotations;

namespace Couponel.Entities.Identities
{
    public sealed class User: Entity
    {
        public User(string userName, string firstName, string lastName, string email, string passwordHash, string userType)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            UserType = userType;
        }


        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string UserType { get; set; }
    }
}
