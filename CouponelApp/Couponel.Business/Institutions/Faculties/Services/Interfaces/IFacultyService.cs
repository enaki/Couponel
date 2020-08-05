using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Entities.Institutions;

namespace Couponel.Business.Institutions.Faculties.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<FacultyModel> GetByIdWithAddress(Guid universityId, Guid facultyId);
        Task<FacultyModel> Add(CreateFacultyModel model);
        Task Delete(Guid universityId, Guid facultyId);
        Task<IEnumerable<ListFacultyModel>> GetAllByUniversityId(Guid Id);
        Task Update(UpdateFacultyModel model);
    }
}
