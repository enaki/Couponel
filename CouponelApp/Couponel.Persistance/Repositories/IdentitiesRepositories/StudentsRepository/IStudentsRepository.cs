using Couponel.Entities.Coupons;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Couponel.Persistence.Repositories.IdentitiesRepositories.StudentsRepository
{
    public interface IStudentsRepository : IUsersWithRolesRepository<Student>
    {
        public Task<IList<Student>> GetStudentWithRedeemedCopons(Guid id);
    }
}
