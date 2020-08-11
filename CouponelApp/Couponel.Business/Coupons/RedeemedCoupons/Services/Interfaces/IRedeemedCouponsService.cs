using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Couponel.Business.Coupons.RedeemedCoupons.Models;
using Couponel.Entities.Coupons;

namespace Couponel.Business.Coupons.RedeemedCoupons.Services.Interfaces
{
    public interface IRedeemedCouponsService
    {
        Task<RedeemedCouponModel> Get(Guid redeemedCouponId);
        Task<IList<ListRedeemedCouponModel>> GetAll();
        Task<RedeemedCouponModel> Add(Guid redeemedCouponId);
        Task UpdateStatus(Guid redeemedCouponId, string newStatus);
        Task Delete(Guid id);
        Task<IList<ListRedeemedCouponModel>> GetAllWithAdmin();
    }
}
