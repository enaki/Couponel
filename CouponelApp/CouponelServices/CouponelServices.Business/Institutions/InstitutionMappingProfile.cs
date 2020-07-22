using AutoMapper;
using CouponelServices.Business.Institutions.Addresses.Models;
using CouponelServices.Business.Institutions.Faculties.Models;
using CouponelServices.Business.Institutions.Universities.Models;

namespace CouponelServices.Business.Institutions
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
