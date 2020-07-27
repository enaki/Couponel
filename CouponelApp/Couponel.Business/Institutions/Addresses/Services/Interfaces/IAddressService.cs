using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Addresses.Models;

namespace Couponel.Business.Institutions.Addresses.Services.Interfaces
{
    public interface IAddressService
    {
        Task<AddressModel> GetById(Guid addressId);

        Task<AddressModel> Add(CreateAddressModel model);

        Task Delete(Guid addressId);

        Task<IEnumerable<AddressModel>> GetAll();
    }
}
