using AutoMapper;
using Couponel.Business.Institutions.Addresses.Models;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Entities.Institutions;

namespace Couponel.Business.Institutions
{
    public class InstitutionMappingProfile: Profile
    {
        public InstitutionMappingProfile()
        {
            CreateMap<CreateAddressModel, Address>();
            CreateMap<Address, AddressModel>();

            CreateMap<CreateFacultyModel, Faculty>();
            CreateMap<Faculty, FacultyModel>();

            CreateMap<CreateUniversityModel, University>();
            CreateMap<University, UniversityModel>();
        }
    }
}
