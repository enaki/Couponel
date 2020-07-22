using AutoMapper;
using CouponelServices.Business.Institutions.Address.Models;
using CouponelServices.Business.Institutions.Faculty.Models;
using CouponelServices.Business.Institutions.University.Models;

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
