using System;
using System.Threading.Tasks;
using Couponel.Entities;
using Couponel.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Couponel.Persistence.UniversitiesRepository
{
    public sealed class UniversitiesRepository: Repository<University>, IUniversitiesRepository
    {
        public UniversitiesRepository(CouponelContext context) : base(context)
        {
        }

        public async Task<University> GetByIdWithAddressAndFaculties(Guid id)
            => await this.context.Universities
                .Include(university => university.Faculties)
                    .ThenInclude(faculty => faculty.Students)
                .Include(university => university.Address)
                .FirstAsync(university => university.Id == id);
    }
}
