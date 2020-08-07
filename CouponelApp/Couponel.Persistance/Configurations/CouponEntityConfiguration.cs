using Couponel.Entities.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
