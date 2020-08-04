using AutoMapper;
using Couponel.Business.Identities.Admins.Models;
using Couponel.Business.Identities.Offerers.Models;
using Couponel.Business.Identities.Students.Models;
using Couponel.Entities.Identities.UserTypes;

namespace Couponel.Business.Identities
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<CreateStudentModel, Student>();
            CreateMap<Student, StudentModel>();

            CreateMap<CreateOffererModel, Offerer>();
            CreateMap<Offerer, CreateOffererModel>();
        }
    }
}
