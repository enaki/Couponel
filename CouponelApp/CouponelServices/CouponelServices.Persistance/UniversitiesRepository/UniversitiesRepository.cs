using CouponelServices.Entities;
using CouponelServices.Persistence.Repository;

namespace CouponelServices.Persistence.UniversitiesRepository
{
    public sealed class UniversitiesRepository: Repository<University>, IUniversitiesRepository
    {
        public UniversitiesRepository(CouponelContext context) : base(context)
        {
        }
    }
}
