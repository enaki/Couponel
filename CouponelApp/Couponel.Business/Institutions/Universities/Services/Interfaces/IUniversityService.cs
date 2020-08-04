using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Universities.Models;

namespace Couponel.Business.Institutions.Universities.Services.Interfaces
{
    public interface IUniversityService
    {
        Task<UniversityModel> GetByIdWithAddressAndFaculties(Guid universityId);
        Task<UniversityModel> Add(CreateUniversityModel model);
        Task Delete(Guid universityId);
        Task<IEnumerable<ListUniversityModel>> GetAll();
        Task Update(Guid universityId, UpdateUniversityModel model);
    }
}
