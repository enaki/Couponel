using System.Threading.Tasks;
using Couponel.Entities.Identities;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.UsersRepository
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<User> GetByUsername(string username);
    }
}
