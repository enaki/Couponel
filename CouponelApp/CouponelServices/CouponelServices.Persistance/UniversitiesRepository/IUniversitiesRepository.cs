using CouponelServices.Entities;
using CouponelServices.Persistence.Repository;
using System;
using System.Threading.Tasks;

namespace CouponelServices.Persistence.UniversitiesRepository
{
    public interface IUniversitiesRepository: IRepository<Entities.University>
    {
        public Task<University> GetByIdWithAddressAndFaculties(Guid id);
    }
    
}
