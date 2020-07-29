using System;
using System.Threading.Tasks;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.CouponsRepositories.CouponsRepository
{
    public interface ICouponsRepository : IRepository<Coupon>
    {
        Task<Coupon> GetByIdWithComments(Guid id);
    }
}
