using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Couponel.Business.Identities.Users.Models;
using Couponel.Entities.ValueObjects;

namespace Couponel.Business.Identities.Users.Services
{
    public class UserDetailsModel:IUserDetailsModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
