using AutoMapper;
using Couponel.Business.Identities.Students.Models;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Entities.Institutions;

namespace Couponel.Business.Identities
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<University, StudentDetailsModel>();
        }
    }
}
