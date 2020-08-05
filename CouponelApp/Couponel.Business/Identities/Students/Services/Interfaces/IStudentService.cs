using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Identities.Students.Models;

namespace Couponel.Business.Identities.Students.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<StudentInstitutionsDetailsModel> GetStudentDetailsById(Guid studentId);
        public Task AddStudentToFaculty(Guid universityId, Guid facultyId, Guid userId);
    }
}
