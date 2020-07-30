using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Business.Authentications.Models
{
    public sealed class AuthenticationResponse
    {
        public AuthenticationResponse(string username, string firstName, string lastName, string token)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Token = token;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Username { get; private set; }

        public string Token { get; private set; }
    }
}
