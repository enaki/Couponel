using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.OfferersRepository
{
    public sealed class OfferersRepository : Repository<Offerer>, IOfferersRepository
    {
        public OfferersRepository(CouponelContext context) : base(context) { }

        public async Task<IList<Offerer>> GetAllByFirstName(string firstName) =>
                await this.context.Offerers.Where(x => x.User.FirstName == firstName).ToListAsync();

        public async Task<IList<Offerer>> GetAllByFirstNameWithUser(string firstName) =>
                await this.context.Offerers.Where(x => x.User.FirstName == firstName)
                            .Include(x => x.User)
                            .ToListAsync();

        public async Task<IList<Offerer>> GetAllByLastName(string lastName) =>
                await this.context.Offerers.Where(x => x.User.LastName == lastName).ToListAsync();

        public async Task<IList<Offerer>> GetAllByLastNameWithUser(string lastName) =>
                await this.context.Offerers.Where(x => x.User.LastName == lastName)
                            .Include(x => x.User)
                            .ToListAsync();

        public async Task<Offerer> GetByEmail(string email) =>
            await this.context.Offerers.Where(x => x.User.Email == email).FirstOrDefaultAsync();


        public async Task<Offerer> GetByEmailWithUser(string email) =>
            await this.context.Offerers.Where(x => x.User.Email == email)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();

        public async Task<Offerer> GetByPhoneNumber(string phoneNumber) =>
            await this.context.Offerers.Where(x => x.User.PhoneNumber == phoneNumber).FirstOrDefaultAsync();

        public async Task<Offerer> GetByPhoneNumberWithUser(string phoneNumber) =>
            await this.context.Offerers.Where(x => x.User.PhoneNumber == phoneNumber)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();

    }
}
