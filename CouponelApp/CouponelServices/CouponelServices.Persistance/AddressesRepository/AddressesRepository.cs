using CouponelServices.Entities;
using CouponelServices.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponelServices.Persistence.AddressesRepository
{
    public sealed class AddressesRepository: Repository<Address>, IAddressesRepository
    {
        public AddressesRepository(CouponelContext context) : base(context) { }
    }
}
