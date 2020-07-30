using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Identities.Admins.Models;

namespace Couponel.Business.Identities.Admins.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminModel> GetById(Guid adminId);

        Task<AdminModel> Add(CreateAdminModel model);

        Task Delete(Guid adminId);

        Task<IEnumerable<AdminModel>> GetAll();
    }
}
