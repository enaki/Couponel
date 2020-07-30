using AutoMapper;
using Couponel.Business.Authentications.Models;
using Couponel.Entities.Identities;

namespace Couponel.Business.Authentications
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
