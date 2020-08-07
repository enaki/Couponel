using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Business.Identities.Users.Models;
using Couponel.Entities.Identities;

namespace Couponel.IntegrationTests.Shared
{
    public static class UserRegisterModelFactory
    {
        public static User Admin()
        {
            return new User("mircea", "mircea@yahoo.com", "mircea", "Admin", "Mircea", "Ionescu", "0754268945");
        }
        public static User Student()
        {
            return new User("junior", "junior@yahoo.com", "junior", "Student", "Junior", "Junior", "0754212345");
        }
        public static User Offerer()
        {
            return new User("senior", "senior@yahoo.com", "senior", "Offerer", "Senior", "Senior", "0712348945");
        }
    }
}
