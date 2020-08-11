using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.RedeemedCouponsRepositoriy
{
    public sealed class RedeemedCouponsRepository: Repository<RedeemedCoupon>, IRedeemedCouponsRepository
    {
        public RedeemedCouponsRepository(CouponelContext context) : base(context)
        {
        }
    }
}
