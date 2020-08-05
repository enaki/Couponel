using System;
using Couponel.Entities.Identities;
using Couponel.Entities.Institutions;
<<<<<<< HEAD:CouponelApp/Couponel.Business/Authentications/Models/UserRegisterModel.cs
using System;
using System.Collections.Generic;
using System.Text;
=======
>>>>>>> origin/Co-25:CouponelApp/Couponel.Business/Identities/Users/Models/UserRegisterModel.cs
using Couponel.Entities.ValueObjects;

namespace Couponel.Business.Identities.Users.Models
{
    public sealed class UserRegisterModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role{ get; set; }
        public string PhoneNumber { get; set; }
        public Guid universityId { get; set; }
        public Guid facultyId { get; set; }
        public Address Address { get; set; }
    }
}
