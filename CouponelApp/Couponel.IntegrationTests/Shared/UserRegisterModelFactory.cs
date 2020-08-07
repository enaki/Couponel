using Couponel.Business.Authentications.Services.Implementations;
using Couponel.Business.Authentications.Services.Interfaces;
using Couponel.Business.Identities.Users.Models;
using Couponel.Entities.Identities;

namespace Couponel.IntegrationTests.Shared
{
    public abstract class UserAbstractFactory
    {
        protected IPasswordHasher PassHasherService = new PasswordHasher();
        public abstract User getUser();
        public abstract UserRegisterModel getUserModel();
    }

    public class AdminFactory : UserAbstractFactory
    {
        private const string Username = "admin"; 
        private const string Email = "admin@yahoo.com";
        private const string Password = "admin";
        private const string Role = "Admin";
        private const string FirstName = "Mircea";
        private const string LastName = "Ionescu";
        private const string PhoneNumber = "0754268945";
        public override User getUser()
        {
            return new User(Username, Email, PassHasherService.CreateHash(Password), Role, FirstName, LastName, PhoneNumber);
        }

        public override UserRegisterModel getUserModel()
        {
            return new UserRegisterModel
            {
                UserName = Username,
                Email = Email,
                Password = Password,
                Role = Role,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber
            };
        }
    }

    public class UserFactory : UserAbstractFactory
    {
        private const string Username = "user";
        private const string Email = "user@yahoo.com";
        private const string Password = "user";
        private const string Role = "User";
        private const string FirstName = "Mircea";
        private const string LastName = "Ionescu";
        private const string PhoneNumber = "0754268945";
        public override User getUser()
        {
            return new User(Username, Email, PassHasherService.CreateHash(Password), Role, FirstName, LastName, PhoneNumber);
        }

        public override UserRegisterModel getUserModel()
        {
            return new UserRegisterModel
            {
                UserName = Username,
                Email = Email,
                Password = Password,
                Role = Role,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber
            };
        }
    }

    public class OffererFactory : UserAbstractFactory
    {
        private const string Username = "offerer";
        private const string Email = "offerer@yahoo.com";
        private const string Password = "offerer";
        private const string Role = "Offerer";
        private const string FirstName = "Mircea";
        private const string LastName = "Ionescu";
        private const string PhoneNumber = "0754268945";
        public override User getUser()
        {
            return new User(Username, Email, PassHasherService.CreateHash(Password), Role, FirstName, LastName, PhoneNumber);
        }

        public override UserRegisterModel getUserModel()
        {
            return new UserRegisterModel
            {
                UserName = Username,
                Email = Email,
                Password = Password,
                Role = Role,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber
            };
        }
    }

    public static class UserRegisterModelFactory
    {
        public static UserAbstractFactory getUserFactory(string role)
        {
            return role switch
            {
                UserRole.Admin => new AdminFactory(),
                UserRole.Offerer => new OffererFactory(),
                _ => new UserFactory()
            };
        }

    }
}
