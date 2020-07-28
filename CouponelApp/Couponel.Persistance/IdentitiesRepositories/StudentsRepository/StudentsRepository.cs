using Couponel.Entities.Identities;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repository;

namespace Couponel.Persistence.IdentitiesRepositories.StudentsRepository
{
    public sealed class StudentsRepository : Repository<Student>, IStudentsRepository
    {
        public StudentsRepository(CouponelContext context) : base(context) { }
    }
}
