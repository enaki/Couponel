using System;

namespace Couponel.Business.Coupons.Coupons.Models.CouponsModels
{
    public sealed class CouponModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
    }
}
