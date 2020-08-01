using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.AdminsRepository
{
    public interface IAdminsRepository : IPersonRepository<Admin>, IUsersWithRolesRepository<Admin>
    {
    }
}
