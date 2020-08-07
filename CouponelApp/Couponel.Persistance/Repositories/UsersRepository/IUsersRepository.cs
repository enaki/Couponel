using System;
using System.Threading.Tasks;
using Couponel.Entities.Identities;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.UsersRepository
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<User> GetByUsername(string username);
        Task<Student> GetStudentRedeemedCouponsById(Guid id);
        Task<Student> GetStudentRedeemedCouponById(Guid id, Guid redeemedCouponId);
        Task<Student> GetStudentRedeemedCouponsWithCouponDependecyById(Guid id);
        Task<User> GetOffererWithCouponsById(Guid userId);
    }
}
