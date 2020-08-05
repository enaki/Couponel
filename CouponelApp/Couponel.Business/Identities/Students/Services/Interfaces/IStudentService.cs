using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Identities.Students.Models;

namespace Couponel.Business.Identities.Students.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<StudentDetailsModel> GetStudentDetailsById(Guid studentId);
    }
}
