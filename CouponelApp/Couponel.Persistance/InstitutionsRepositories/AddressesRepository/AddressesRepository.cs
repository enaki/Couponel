using Couponel.Entities.Institutions;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.InstitutionsRepositories.AddressesRepository
{
    public sealed class AddressesRepository: Repository<Address>, IAddressesRepository
    {
        public AddressesRepository(CouponelContext context) : base(context) { }
    }
}
