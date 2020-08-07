using System;
using System.Collections.Generic;
using Couponel.Entities.Coupons;

namespace Couponel.Business.Coupons.Coupons.Models.CouponsModels
{
    public sealed class CouponModelExtended
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
