using System.Threading.Tasks;
using Couponel.Business.Authentications.Models;

namespace Couponel.Business.Authentications.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest userAuthenticationModel);

        Task<UserModel> Register(UserRegisterModel userRegisterModel);
    }
}
