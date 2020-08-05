using Couponel.Entities.Identities;
using Couponel.Entities.Institutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Business.Identities.Users
{
    public sealed class UpdateUserModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
    }
}
