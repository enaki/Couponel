using CouponelServices.Entities;
using CouponelServices.Persistence.Repository;

namespace CouponelServices.Persistence.UniversityRepository
{
    public sealed class UniversityRepository: Repository<University>, IUniversityRepository
    {
        public UniversityRepository(CouponelContext context) : base(context)
        {
        }
    }
}
