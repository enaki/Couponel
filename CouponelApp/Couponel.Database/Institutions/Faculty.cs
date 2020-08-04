using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Couponel.Entities.Identities;
using Couponel.Entities.Identities.UserTypes;

namespace Couponel.Entities.Institutions
{
    public sealed class Faculty : Entity
    {
        public Faculty(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Students = new List<Student>();
        }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Student> Students { get; private set; }
        public void Update(string name, string email, string phoneNumber, Address address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
