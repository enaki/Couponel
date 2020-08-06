using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Entities.Identities;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Couponel.Persistence.Repositories.UsersRepository
{
    public sealed class UsersRepository : Repository<User>, IUsersRepository
    {
        private readonly CouponelContext _context;

        public UsersRepository(CouponelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUsername(string username) =>
            await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();

        public async Task<Student> GetStudentRedeemedCouponsById(Guid id) =>
            await _context.Students.Where(s => s.Id == id)
                .Include(s => s.User)
                .ThenInclude(u => u.Address)
                .Include(s => s.RedeemedCoupons)
                .FirstOrDefaultAsync();
        public async Task<Student> GetStudentRedeemedCouponsWithCouponDependecyById(Guid id) =>
            await _context.Students.Where(s => s.Id == id)
                .Include(s => s.User)
                    .ThenInclude(u => u.Address)
                .Include(s => s.RedeemedCoupons)
                    .ThenInclude(rc=>rc.Coupon)
                .FirstOrDefaultAsync();

        public async Task<Student> GetStudentRedeemedCouponById(Guid id, Guid redeemedCouponId) =>
            await _context.Students
                .Where(s => s.Id == id &&
                        s.RedeemedCoupons.Any(rc=> rc.Id==redeemedCouponId))
                .Include(s => s.User)
                    .ThenInclude(u => u.Address)
                .Include(s => s.RedeemedCoupons)
                    .ThenInclude(rc=>rc.Coupon)
                .FirstOrDefaultAsync();
    }
}
