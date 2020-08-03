using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.InstitutionsRepositories.FacultiesRepository
{
    public sealed class FacultiesRepository : Repository<Faculty>, IFacultiesRepository
    {
        public FacultiesRepository(CouponelContext context) : base(context)
        {
        }
        public async Task<Faculty> GetByIdWithAddressStudentsAndStudentsAdreesses(Guid id)
            => await this.context.Faculties
                .Include(faculty => faculty.Students)
                    .ThenInclude(student => student.Address)
                .Include(faculty => faculty.Address)
                .FirstOrDefaultAsync(faculty => faculty.Id == id);
        public async Task<Faculty> GetByIdWithAddressAndStudents(Guid id)
            => await this.context.Faculties
                .Include(faculty => faculty.Students)
                .Include(faculty => faculty.Address)
                .FirstOrDefaultAsync(faculty => faculty.Id == id);
        public async Task<Faculty> GetByIdWithStudents(Guid id)
            => await this.context.Faculties
                .Include(faculty => faculty.Students)
                .FirstOrDefaultAsync(faculty => faculty.Id == id);
        public async Task<Faculty> GetByIdWithAddress(Guid id)
            => await this.context.Faculties
                .Include(faculty => faculty.Address)
                .FirstOrDefaultAsync(faculty => faculty.Id == id);

        public async Task<Faculty> GetByIdWithAddressStudentsAndUser(Guid id)
                => await this.context.Faculties
                    .Include(faculty => faculty.Students)
                        .ThenInclude(student => student.User)
                    .Include(faculty => faculty.Address)
                    .FirstOrDefaultAsync(faculty => faculty.Id == id);

        public async Task<Faculty> GetAllDependenciesById(Guid id)
            => await this.context.Faculties
                    .Include(faculty => faculty.Students)
                        .ThenInclude(student => student.Address)
                     .Include(faculty => faculty.Students)
                        .ThenInclude(student => student.RedeemedCoupons)
                    .Include(faculty => faculty.Address)
                    .FirstOrDefaultAsync(faculty => faculty.Id == id);
    }
}
