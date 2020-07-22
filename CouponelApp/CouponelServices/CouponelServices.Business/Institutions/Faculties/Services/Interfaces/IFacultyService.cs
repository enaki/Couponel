using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CouponelServices.Business.Institutions.Faculties.Models;

namespace CouponelServices.Business.Institutions.Faculties.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<FacultyModel> GetById(Guid facultyId);

        Task<FacultyModel> Add(CreateFacultyModel model);

        Task Delete(Guid facultyId);

        Task<IEnumerable<FacultyModel>> GetAll();
    }
}
