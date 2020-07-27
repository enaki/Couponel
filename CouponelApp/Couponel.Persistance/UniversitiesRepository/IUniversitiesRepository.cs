using System;
using System.Threading.Tasks;
using Couponel.Entities;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.UniversitiesRepository
{
    public interface IUniversitiesRepository: IRepository<Entities.University>
    {
        public Task<University> GetByIdWithAddressAndFaculties(Guid id);
    }
    
}
