using AutoMapper;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.Business.Identities.Students.Models;
using Couponel.Business.Identities.Users.Models;
using Couponel.Entities.Identities;

namespace Couponel.Business.Identities
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<UpdateUserModel, User>();
            CreateMap<User, UserDetailsModel>();
            CreateMap<UserDetailsModel, StudentDetailsModel>();
            CreateMap<User, OffererCouponsListModel>();
        }
    }
}
