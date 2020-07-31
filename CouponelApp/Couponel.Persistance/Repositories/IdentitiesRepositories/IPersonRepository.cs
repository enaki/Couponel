using Couponel.Entities.Identities;
using Couponel.Persistence.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories
{
    public interface IPersonRepository<T> : IRepository<T>
        where T:Person
    {
        public Task<IList<T>> GetAllByFirstName(string firstName);
        public Task<IList<T>> GetAllByLastName(string lastName);
        public Task<T> GetByEmail(string email);
        public Task<T> GetByPhoneNumber(string phoneNumber);
    }
}
