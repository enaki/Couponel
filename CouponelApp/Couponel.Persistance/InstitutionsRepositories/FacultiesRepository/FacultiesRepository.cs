using Couponel.Entities.Institutions;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.InstitutionsRepositories.FacultiesRepository
{
    public sealed class FacultiesRepository: Repository<Faculty>, IFacultiesRepository
    {
        public FacultiesRepository(CouponelContext context) : base(context)
        {
        }
    }
}
