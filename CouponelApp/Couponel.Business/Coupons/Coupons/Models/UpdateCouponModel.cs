using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Business.Coupons.Coupons.Models
{
    public sealed class UpdateCouponModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
    }
}
