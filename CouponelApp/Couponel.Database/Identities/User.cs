using Couponel.Entities.Coupons;
using Couponel.Entities.Institutions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Couponel.Entities.ValueObjects;

namespace Couponel.Entities.Identities
{
    public static class Role
    {
        public const string Student = "Student";
        public const string Offerer = "Offerer";
        public const string Admin = "Admin";
    }

    public sealed class User : Entity
    {
        public User(string userName, string email, string passwordHash, string role, string firstName, string lastName, string phoneNumber)
               : base()
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Role = role;
            if (role == Identities.Role.Offerer)
                Coupons = new List<Coupon>();
        }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Coupon> Coupons {get; private set;}

        public void AddCoupon(Coupon coupon)
        {
            Coupons.Add(coupon);
        }
        public void RemoveCoupon(Guid couponId)
        {
            var comment = this.Coupons.FirstOrDefault(c => c.Id == couponId);

            if (comment != null)
            {
                Coupons.Remove(comment);
            }
        }
        public void Update(string email, string passwordHash,
            string firstName, string lastName, string phoneNumber, Address address)
        {
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }
    }
}
