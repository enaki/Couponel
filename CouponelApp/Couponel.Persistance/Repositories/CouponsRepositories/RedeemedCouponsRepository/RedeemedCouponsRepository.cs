using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.CouponsRepositories.RedeemedCouponsRepository
{
    public class RedeemedCouponsRepository : Repository<RedeemedCoupon> , IRedeemedCouponsRepository
    {
        public RedeemedCouponsRepository(CouponelContext context) : base(context) { }

        public async Task<RedeemedCoupon> GetByIdWithCoupon(Guid id) =>
             await this.context.RedeemedCoupons.Where(x => x.Id == id)
                    .Include(x => x.Coupon)
                    .FirstOrDefaultAsync();
    }
}
