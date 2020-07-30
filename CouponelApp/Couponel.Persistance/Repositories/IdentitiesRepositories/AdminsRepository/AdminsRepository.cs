using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.AdminsRepository
{
    public sealed class AdminsRepository : Repository<Admin>, IAdminsRepository
    {
        public AdminsRepository(CouponelContext context) : base(context) { }
    }
}
