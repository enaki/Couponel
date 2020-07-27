using AutoMapper;
using Couponel.Business.Institutions.Addresses.Models;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Universities.Models;

namespace Couponel.Business.Institutions
{
    public class InstitutionMappingProfile: Profile
    {
        public InstitutionMappingProfile()
        {
            CreateMap<CreateAddressModel, Entities.Address>();
            CreateMap<Entities.Address, AddressModel>();

            CreateMap<CreateFacultyModel, Entities.Faculty>();
            CreateMap<Entities.Faculty, FacultyModel>();

            CreateMap<CreateUniversityModel, Entities.University>();
            CreateMap<Entities.University, UniversityModel>();
        }
    }
}
