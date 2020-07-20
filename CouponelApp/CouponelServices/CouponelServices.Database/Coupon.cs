using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CouponelServices.Entities
{
    public sealed class Coupon: Entity
    {
        public Coupon(string name, string category, DateTime expirationDate, string description)
        {
            Name = name;
            Category = category;
            DateAdded = DateTime.Now;
            ExpirationDate = expirationDate;
            Description = description;
        }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Category { get; private set; }

        [Required]
        public DateTime DateAdded { get; private set; }

        [Required]
        public DateTime ExpirationDate { get; private set; }
    
        [Required]
        public string Description { get; private set; }
    }
}
