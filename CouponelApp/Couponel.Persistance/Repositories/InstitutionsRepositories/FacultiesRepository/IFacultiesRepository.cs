using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.Repository;
using System;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.InstitutionsRepositories.FacultiesRepository
{
    public interface IFacultiesRepository: IRepository<Faculty>
    {
        public Task<Faculty> GetByIdWithAddressStudentsAndStudentsAdreesses(Guid id);
        public Task<Faculty> GetByIdWithAddressAndStudents(Guid id);
        public Task<Faculty> GetByIdWithStudents(Guid id);
        public Task<Faculty> GetByIdWithAddress(Guid id);
        public Task<Faculty> GetByIdWithAddressStudentsAndUser(Guid id);
        public Task<Faculty> GetAllDependenciesById(Guid id);

    }
}
