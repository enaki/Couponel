
namespace Couponel.Business.Authentications.Models
{
    public sealed class AuthenticationResponse
    {
        public AuthenticationResponse(string username, string token)
        {
            Username = username;
            Token = token;
        }
        public string Username { get; private set; }
        public string Token { get; private set; }
    }
}
