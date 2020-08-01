using Couponel.Entities.Coupons;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.StudentsRepository
{
    public sealed class StudentsRepository : Repository<Student>, IStudentsRepository
    {
        public StudentsRepository(CouponelContext context) : base(context) { }

        public async Task<IList<Student>> GetAllByFirstName(string firstName) =>
                await this.context.Students.Where(x=> x.FirstName== firstName).ToListAsync();

        public async Task<IList<Student>> GetAllByFirstNameWithUser(string firstName) =>
                await this.context.Students.Where(x => x.FirstName == firstName)
                            .Include(x=>x.User)
                            .ToListAsync();

        public async Task<IList<Student>> GetAllByLastName(string lastName)=>
                await this.context.Students.Where(x => x.LastName == lastName).ToListAsync();

        public async Task<IList<Student>> GetAllByLastNameWithUser(string lastName) =>
                await this.context.Students.Where(x => x.LastName == lastName)
                            .Include(x => x.User)
                            .ToListAsync();

        public async Task<Student> GetByEmail(string email) =>
            await this.context.Students.Where(x => x.User.Email == email).FirstOrDefaultAsync();

        public async Task<Student> GetByEmailWithUser(string email) =>
            await this.context.Students.Where(x => x.User.Email == email)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();

        public async Task<Student> GetByPhoneNumber(string phoneNumber) =>
            await this.context.Students.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();

        public async Task<Student> GetByPhoneNumberWithUser(string phoneNumber) =>
            await this.context.Students.Where(x => x.PhoneNumber == phoneNumber)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();

        public async Task<IList<Student>> GetStudentWithRedeemedCopons(Guid id) =>
            await this.context.Students.Where(x => x.Id == id)
                            .Include(x => x.RedeemedCoupons)
                            .ToListAsync();
    }
}
