using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CouponelServices.Business.Institutions.Faculty.Models;

namespace CouponelServices.Business.Institutions.Faculty.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<FacultyModel> GetById(Guid facultyId);

        Task<FacultyModel> Add(CreateFacultyModel model);

        Task Delete(Guid facultyId);

        Task<IEnumerable<FacultyModel>> GetAll();
    }
}
