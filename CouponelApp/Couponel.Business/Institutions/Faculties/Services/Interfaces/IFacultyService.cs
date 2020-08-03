using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;

namespace Couponel.Business.Institutions.Faculties.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<FacultyModel> GetByIdWithAddressStudentsAndUser(Guid facultyId);

        Task<FacultyModel> Add(CreateFacultyModel model);

        Task Delete(Guid facultyId);

        Task<IEnumerable<ListFacultyModel>> GetAllByUniversityId(Guid Id);
        Task Update(UpdateFacultyModel model);
    }
}
