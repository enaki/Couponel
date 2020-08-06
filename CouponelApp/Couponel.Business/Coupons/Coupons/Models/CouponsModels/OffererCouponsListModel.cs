using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.Coupons;

namespace Couponel.Business.Coupons.Coupons.Models.CouponsModels
{
    public sealed class OffererCouponsListModel
    {
        public IList<Coupon> Coupons { get; set; }
    }
}
