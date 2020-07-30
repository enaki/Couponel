using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Identities.Students.Models;

namespace Couponel.Business.Identities.Students.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentModel> GetById(Guid studentId);

        Task<StudentModel> Add(CreateStudentModel model);

        Task Delete(Guid studentId);

        Task<IEnumerable<StudentModel>> GetAll();
    }
}
