using System.ComponentModel.DataAnnotations;

namespace Couponel.Entities.Identities
{
    public sealed class User : Entity
    {
        public User(string userName, string email, string passwordHash, string role)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }


        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
