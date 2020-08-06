using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models;

namespace Couponel.Business.Coupons.Coupons.Services.Interfaces
{
    public interface ICouponService
    {
        Task<CouponModel> GetById(Guid adminId);

        Task<CouponModel> Add(CreateCouponModel model);

        Task Delete(Guid adminId);

        Task<PaginatedList<CouponModel>> GetBySearchModel(SearchModel model);
    }
}
