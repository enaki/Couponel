using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IList<Student>> GetAllByLastName(string lastName)=>
                await this.context.Students.Where(x => x.LastName == lastName).ToListAsync();

        public async Task<Student> GetByEmail(string email) =>
            await this.context.Students.Where(x => x.Email == email).FirstOrDefaultAsync();
        
        public async Task<Student> GetByPhoneNumber(string phoneNumber) =>
            await this.context.Students.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
    }
}
