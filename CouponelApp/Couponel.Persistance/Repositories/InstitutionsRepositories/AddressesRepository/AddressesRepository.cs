using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.InstitutionsRepositories.AddressesRepository
{
    public sealed class AddressesRepository: Repository<Address>, IAddressesRepository
    {
        public AddressesRepository(CouponelContext context) : base(context) { }
    }
}
