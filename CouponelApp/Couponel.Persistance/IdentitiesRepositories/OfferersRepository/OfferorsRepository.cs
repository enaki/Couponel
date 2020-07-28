using Couponel.Entities.Identities;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.IdentitiesRepositories.OfferersRepository
{
    public sealed class OfferorsRepository : Repository<Offerer>, IOfferorsRepository
    {
        public OfferorsRepository(CouponelContext context) : base(context) { }
    }
}
