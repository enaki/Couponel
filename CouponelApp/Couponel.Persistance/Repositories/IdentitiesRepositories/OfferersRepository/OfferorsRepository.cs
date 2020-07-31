using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.OfferersRepository
{
    public sealed class OfferorsRepository : Repository<Offerer>, IOfferorsRepository
    {
        public OfferorsRepository(CouponelContext context) : base(context) { }

        public async Task<IList<Offerer>> GetAllByFirstName(string firstName) =>
                await this.context.Offerers.Where(x=> x.FirstName== firstName).ToListAsync();

        public async Task<IList<Offerer>> GetAllByLastName(string lastName) =>
                await this.context.Offerers.Where(x => x.LastName == lastName).ToListAsync();

        public async Task<Offerer> GetByEmail(string email)=>
            await this.context.Offerers.Where(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<Offerer> GetByPhoneNumber(string phoneNumber)=>
            await this.context.Offerers.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();

    }
}
