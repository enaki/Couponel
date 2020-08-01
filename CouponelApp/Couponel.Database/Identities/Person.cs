﻿using System.ComponentModel.DataAnnotations;

namespace Couponel.Entities.Identities
{
    public abstract class Person : Entity
    {
        protected Person(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }
        public void Update(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
