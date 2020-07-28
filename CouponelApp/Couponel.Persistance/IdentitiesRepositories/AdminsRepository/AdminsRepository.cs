using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.Identities;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repository;


namespace Couponel.Persistence.IdentitiesRepositories.AdminsRepository
{
    public sealed class AdminsRepository : Repository<Admin>, IAdminsRepository
    {
        public AdminsRepository(CouponelContext context) : base(context) { }
    }
}
