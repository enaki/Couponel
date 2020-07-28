using System;
using System.Threading.Tasks;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.InstitutionsRepositories.UniversitiesRepository
{
    public interface IUniversitiesRepository: IRepository<University>
    {
        public Task<University> GetByIdWithAddressAndFaculties(Guid id);
    }
    
}
