using System;
using System.Threading.Tasks;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Couponel.Persistence.Repositories.InstitutionsRepositories.UniversitiesRepository
{
    public sealed class UniversitiesRepository : Repository<University>, IUniversitiesRepository
    {
        public UniversitiesRepository(CouponelContext context) : base(context)
        {
        }

        public async Task<University> GetByIdWithAddressFacultiesAndStudents(Guid id)
            => await this.context.Universities
                .Include(university => university.Faculties)
                    .ThenInclude(faculty => faculty.Students)
                .Include(university => university.Address)
                .FirstAsync(university => university.Id == id);
        public async Task<University> GetByIdWithAddressAndFaculties(Guid id)
        => await this.context.Universities
            .Include(university => university.Faculties)
            .Include(university => university.Address)
            .FirstAsync(university => university.Id == id);

        public async Task<University> GetByIdWithFacultiesAndStudents(Guid id)
                => await this.context.Universities
                    .Include(university => university.Faculties)
                        .ThenInclude(faculty => faculty.Students)
                    .FirstAsync(university => university.Id == id);

        public async Task<University> GetByIdWithFaculties(Guid id)
        => await this.context.Universities
            .Include(university => university.Faculties)
            .FirstAsync(university => university.Id == id);

        public async Task<University> GetByIdWithAddress(Guid id)
                => await this.context.Universities
                    .Include(university => university.Address)
                    .FirstAsync(university => university.Id == id);

    }
}
