using AutoMapper;
using CouponelServices.Business.Institutions.Address.Models;
using CouponelServices.Business.Institutions.Faculty.Models;
using CouponelServices.Business.Institutions.University.Models;
using CouponelServices.Entities;

namespace CouponelServices.Business
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
