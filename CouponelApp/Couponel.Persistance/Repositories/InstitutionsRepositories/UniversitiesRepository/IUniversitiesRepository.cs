using System;
using System.Threading.Tasks;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.InstitutionsRepositories.UniversitiesRepository
{
    public interface IUniversitiesRepository: IRepository<University>
    {
        public Task<University> GetByIdWithAddressAndFaculties(Guid id);
    }
    
}
