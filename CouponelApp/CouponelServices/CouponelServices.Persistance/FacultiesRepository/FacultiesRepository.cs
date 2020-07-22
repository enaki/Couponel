using CouponelServices.Entities;
using CouponelServices.Persistence.Repository;

namespace CouponelServices.Persistence.FacultiesRepository
{
    public sealed class FacultiesRepository: Repository<Faculty>, IFacultiesRepository
    {
        public FacultiesRepository(CouponelContext context) : base(context)
        {
        }
    }
}
