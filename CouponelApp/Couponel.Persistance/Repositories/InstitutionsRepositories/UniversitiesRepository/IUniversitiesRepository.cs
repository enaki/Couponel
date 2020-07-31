using System;
using System.Threading.Tasks;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.InstitutionsRepositories.UniversitiesRepository
{
    public interface IUniversitiesRepository: IRepository<University>
    {
        public Task<University> GetByIdWithAddress(Guid id);
        public Task<University> GetByIdWithFaculties(Guid id);
        public Task<University> GetByIdWithFacultiesAndStudents(Guid id);
        public Task<University> GetByIdWithAddressAndFaculties(Guid id);
        public Task<University> GetByIdWithAddressFacultiesAndStudents(Guid id);
    }
    
}
