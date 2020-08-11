using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.UniversitiesRepository
{
    public interface IUniversitiesRepository: IRepository<University>
    {
        public Task<University> GetByIdWithFaculties(Guid id);
        public Task<University> GetByStudentId(Guid studentId);
        public Task<University> GetByIdWithFacultiesAndStudents(Guid universityId, Guid facultyId);  
        public Task<University> GetByIdWithAddressFacultiesAndStudents(Guid id);
        public Task<University> GetAllDependenciesById(Guid id);
        public Task<University> GetByIdWithFacultyAndFacultyAddress(Guid universityId, Guid facultyId);
        public Task<IEnumerable<University>> GetAllWithFaculties();
    }
    
}
