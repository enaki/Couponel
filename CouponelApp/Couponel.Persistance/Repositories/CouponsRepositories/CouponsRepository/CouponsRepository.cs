using System;
using System.Threading.Tasks;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Couponel.Persistence.Repositories.CouponsRepositories.CouponsRepository
{
    public sealed class CouponsRepository: Repository<Coupon>, ICouponsRepository
    {
        public CouponsRepository(CouponelContext context) : base(context) { }
        public async Task<Coupon> GetByIdWithComments(Guid id)
            => await this.context.Coupons
                .Include(coupon => coupon.Comments)
                .FirstAsync(coupon => coupon.Id == id);
    }
}
