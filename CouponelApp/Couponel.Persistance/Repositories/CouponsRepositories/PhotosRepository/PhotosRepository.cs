using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.CouponsRepositories.CommentsRepository
{
    public sealed class PhotosRepository: Repository<Photo>, IPhotosRepository
    {
        public PhotosRepository(CouponelContext context) : base(context) { }
        
    }
}
