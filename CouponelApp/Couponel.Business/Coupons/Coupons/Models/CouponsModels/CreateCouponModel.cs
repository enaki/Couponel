
using System;

namespace Couponel.Business.Coupons.Coupons.Models
{
    public sealed class CreateCouponModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
    }
}
