using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.CouponsRepositories.RedeemedCouponsRepository
{
    public interface IRedeemedCouponsRepository : IRepository<RedeemedCoupon>
    {
        public Task<RedeemedCoupon> GetByIdWithCoupon(Guid id);
    }
}
