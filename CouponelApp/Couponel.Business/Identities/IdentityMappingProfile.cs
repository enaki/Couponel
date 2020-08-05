using AutoMapper;
using Couponel.Business.Identities.Students.Models;
using Couponel.Business.Identities.Users.Models;
using Couponel.Entities.Identities;
using Couponel.Entities.Institutions;

namespace Couponel.Business.Identities
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<University, StudentDetailsModel>();

            CreateMap<UpdateUserModel, User>();
        }
    }
}
