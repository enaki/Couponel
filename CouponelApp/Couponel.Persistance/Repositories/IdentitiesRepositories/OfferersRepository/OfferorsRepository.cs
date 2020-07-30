using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.OfferersRepository
{
    public sealed class OfferorsRepository : Repository<Offerer>, IOfferorsRepository
    {
        public OfferorsRepository(CouponelContext context) : base(context) { }
    }
}
