using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.CouponsRepositories.CommentsRepository
{
    public sealed class CommentsRepository: Repository<Comment>, ICommentsRepository
    {
        public CommentsRepository(CouponelContext context) : base(context) { }
        
    }
}
