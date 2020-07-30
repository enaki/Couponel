using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Business.Authentications.Models
{
    public sealed class UserModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
