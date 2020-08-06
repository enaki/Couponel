using Couponel.Entities.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Persistence.Configurations
{
    public class CouponEntityConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> couponConfiguration)
        {
            couponConfiguration
                .HasMany<Comment>(coupon => coupon.Comments)
                .WithOne()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            couponConfiguration
                .HasMany<Photo>(coupon => coupon.Photos)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientCascade);

            couponConfiguration
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}
