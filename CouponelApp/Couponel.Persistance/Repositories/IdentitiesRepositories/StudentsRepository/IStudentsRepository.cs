using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.StudentsRepository
{
    public interface IStudentsRepository : IPersonRepository<Student>
    {
    }
}
