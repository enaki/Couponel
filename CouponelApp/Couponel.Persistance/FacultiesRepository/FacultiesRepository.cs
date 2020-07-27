using Couponel.Entities;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.FacultiesRepository
{
    public sealed class FacultiesRepository: Repository<Faculty>, IFacultiesRepository
    {
        public FacultiesRepository(CouponelContext context) : base(context)
        {
        }
    }
}
