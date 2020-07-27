using Couponel.Entities;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.AddressesRepository
{
    public sealed class AddressesRepository: Repository<Address>, IAddressesRepository
    {
        public AddressesRepository(CouponelContext context) : base(context) { }
    }
}
