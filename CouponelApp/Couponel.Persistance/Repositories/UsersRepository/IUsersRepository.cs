using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Entities.Identities;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.UsersRepository
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
        Task<IList<User>> GetAllByRole(string role);
        public Task<User> GetUserDetailsById(Guid id);
        Task<Student> GetStudentRedeemedCouponsById(Guid id);

    }
}
