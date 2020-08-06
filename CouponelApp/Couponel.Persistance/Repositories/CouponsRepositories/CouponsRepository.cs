using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;

namespace Couponel.Persistence.Repositories.CouponsRepositories
{
    public sealed class CouponsRepository: Repository<Coupon>, ICouponsRepository
    {
        public CouponsRepository(CouponelContext context) : base(context)
        {
        }
        public async Task<Coupon> GetByIdWithPhotosAndComments(Guid couponId)
            => await this.context.Coupons
                .Include(coupon => coupon.Comments)
                .Include(coupon => coupon.Photos)
                .FirstAsync(coupon => coupon.Id == couponId);

        public async  Task<IList<Coupon>> GetBySpecification(ISpecification<Coupon> spec)
            => await this.context.Coupons.ExeSpec(spec)
                .ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Coupons.CountAsync();
    }
}
