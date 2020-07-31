using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.StudentsRepository
{
    public interface IStudentsRepository : IRepository<Student>
    {
        public Task<IList<Student>> GetAllByFirstName(string firstName);
        public Task<IList<Student>> GetAllByLastName(string lastName);
        public Task<Student> GetByEmail(string email);
        public Task<Student> GetByPhoneNumber(string phoneNumber);
    }
}
