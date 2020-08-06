using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;
using LinqBuilder.Core;

namespace Couponel.Persistence.Repositories.CouponsRepositories
{
    public interface ICouponsRepository : IRepository<Coupon>
    {
        Task<Coupon> GetByIdWithPhotosAndComments(Guid couponId);
        Task<IList<Coupon>> GetBySpecification(ISpecification<Coupon> spec);
        Task<int> CountAsync();
    }
}
