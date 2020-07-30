using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Business.Authentications.Models
{
    public sealed class UserRegisterModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
