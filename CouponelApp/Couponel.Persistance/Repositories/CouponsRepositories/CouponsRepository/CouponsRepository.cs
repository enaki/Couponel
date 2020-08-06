using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Couponel.Persistence.Repositories.CouponsRepositories.CouponsRepository
{
    public sealed class CouponsRepository: Repository<Coupon>, ICouponsRepository
    {
        public CouponsRepository(CouponelContext context) : base(context) { }
        public async Task<Coupon> GetByIdWithComments(Guid couponId)
            => await this.context.Coupons
                .Include(coupon => coupon.Comments)
                .FirstAsync(coupon => coupon.Id == couponId);

        public async Task<Coupon> GetByIdWithPhotos(Guid couponId)
            => await this.context.Coupons
                .Include(coupon => coupon.Photos)
                .FirstAsync(coupon => coupon.Id == couponId);

        public async  Task<IList<Coupon>> GetBySpecification(ISpecification<Coupon> spec)
            => await this.context.Coupons.ExeSpec(spec)
                .ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Coupons.CountAsync();
    }
}
