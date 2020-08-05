using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Entities.Identities;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.UsersRepository
{
    public sealed class UsersRepository : Repository<User>, IUsersRepository
    {
        private readonly CouponelContext _context;

        public UsersRepository(CouponelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetAllByRole(UserRole role) =>
            await _context.Users.Where(x => x.Role == role).ToListAsync();

        public async Task<User> GetByEmail(string email) =>
            await _context.Users.Where(x => x.UserName == email).FirstOrDefaultAsync();

        public async Task<User> GetByUsername(string username) =>
            await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

        public async Task<Student> GetStudentRedeemedCouponsById(Guid id) =>
            await _context.Students.Where(s => s.Id == id)
                        .Include(s => s.User)
                        .ThenInclude(u => u.Address)
                        .Include(s => s.RedeemedCoupons)
                        .FirstOrDefaultAsync();
    }
}
