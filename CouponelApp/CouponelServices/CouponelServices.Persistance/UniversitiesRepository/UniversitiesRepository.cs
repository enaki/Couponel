using CouponelServices.Entities;
using CouponelServices.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CouponelServices.Persistence.UniversitiesRepository
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
