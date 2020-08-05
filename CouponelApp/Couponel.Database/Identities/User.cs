using Couponel.Entities.Coupons;
using Couponel.Entities.Institutions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Couponel.Entities.ValueObjects;

namespace Couponel.Entities.Identities
{
    public enum UserRole { Student=1, Offerer, Admin}
    public sealed class User : Entity
    {
        public User(string userName, string email, string passwordHash, UserRole role, string firstName, string lastName, string phoneNumber)
               : base()
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            if (role == UserRole.Offerer)
                Coupons = new List<Coupon>();
        }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public UserRole Role { get; set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Coupon> Coupons {get; private set;}
        public void Update(string email, string passwordHash, UserRole role,
            string firstName, string lastName, string phoneNumber, Address address)
        {
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
