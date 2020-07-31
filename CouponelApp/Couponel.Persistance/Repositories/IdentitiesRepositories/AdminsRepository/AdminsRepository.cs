using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.AdminsRepository
{
    public sealed class AdminsRepository : Repository<Admin>, IAdminsRepository
    {
        public AdminsRepository(CouponelContext context) : base(context) { }

        public async Task<IList<Admin>> GetAllByFirstName(string firstName) =>
                await this.context.Admins.Where(x => x.FirstName == firstName).ToListAsync();

        public async Task<IList<Admin>> GetAllByFirstNameWithUser(string firstName) =>
                await this.context.Admins.Where(x => x.FirstName == firstName)
                            .Include(x => x.User)
                            .ToListAsync();

        public async Task<IList<Admin>> GetAllByLastName(string lastName) =>
                await this.context.Admins.Where(x => x.LastName == lastName).ToListAsync();

        public async Task<IList<Admin>> GetAllByLastNameWithUser(string lastName) =>
                await this.context.Admins.Where(x => x.LastName == lastName)
                            .Include(x => x.User)
                            .ToListAsync();

        public async Task<Admin> GetByEmail(string email) =>
            await this.context.Admins.Where(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<Admin> GetByEmailWithUser(string email) =>
            await this.context.Admins.Where(x => x.Email == email)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();

        public async Task<Admin> GetByPhoneNumber(string phoneNumber) =>
            await this.context.Admins.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();

        public async Task<Admin> GetByPhoneNumberWithUser(string phoneNumber) =>
            await this.context.Admins.Where(x => x.PhoneNumber == phoneNumber)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();

    }
}
