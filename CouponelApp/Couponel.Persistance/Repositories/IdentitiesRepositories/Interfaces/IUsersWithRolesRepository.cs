using Couponel.Entities;
using Couponel.Persistence.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories
{
    public interface IUsersWithRolesRepository<T>: IRepository<T>
        where T: Entity
    {
        public Task<IList<T>> GetAllByFirstName(string firstName);
        public Task<IList<T>> GetAllByLastName(string lastName);
        public Task<T> GetByEmail(string email);
        public Task<T> GetByPhoneNumber(string phoneNumber);
        public Task<IList<T>> GetAllByFirstNameWithUser(string firstName);
        public Task<IList<T>> GetAllByLastNameWithUser(string lastName);
        public Task<T> GetByEmailWithUser(string email);
        public Task<T> GetByPhoneNumberWithUser(string phoneNumber);
    }
}
