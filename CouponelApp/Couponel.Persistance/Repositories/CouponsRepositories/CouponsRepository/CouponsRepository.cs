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
        public async Task<Coupon> GetByIdWithComments(Guid couponId)
            => await this.context.Coupons
                .Include(coupon => coupon.Comments)
                .FirstAsync(coupon => coupon.Id == couponId);

        public async Task<Coupon> GetByIdWithPhotos(Guid couponId)
            => await this.context.Coupons
                .Include(coupon => coupon.Photos)
                .FirstAsync(coupon => coupon.Id == couponId);
    }
}
