using Couponel.Entities;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.StudentsRepository
{
    public sealed class StudentsRepository : Repository<Student>, IStudentsRepository
    {
        public StudentsRepository(CouponelContext context) : base(context) { }
    }
}
