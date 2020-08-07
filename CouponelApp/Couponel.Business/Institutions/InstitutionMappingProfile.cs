using AutoMapper;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Entities.Institutions;

namespace Couponel.Business.Institutions
{
    public class InstitutionMappingProfile: Profile
    {
        public InstitutionMappingProfile()
        {
            CreateMap<CreateFacultyModel, Faculty>();
            CreateMap<Faculty, FacultyModel>();
            CreateMap<Faculty, ListFacultyModel>();
            CreateMap<UpdateFacultyModel, Faculty>();

            CreateMap<CreateUniversityModel, University>();
            CreateMap<University, UniversityModel>();
            CreateMap<University, ListUniversityModel>();
            CreateMap<UpdateUniversityModel, University>();
        }
    }
}
