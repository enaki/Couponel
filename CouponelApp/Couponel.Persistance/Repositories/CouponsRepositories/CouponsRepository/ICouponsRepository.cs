using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;
using LinqBuilder.Core;

namespace Couponel.Persistence.Repositories.CouponsRepositories.CouponsRepository
{
    public interface ICouponsRepository : IRepository<Coupon>
    {
        Task<Coupon> GetByIdWithComments(Guid couponId);
        Task<Coupon> GetByIdWithPhotos(Guid couponId);
        Task<IList<Coupon>> GetBySpecification(ISpecification<Coupon> spec);
        Task<int> CountAsync();
    }
}
