using Couponel.Entities.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Couponel.Persistence.Configurations
{
    public class RedeemedCouponEntityConfiguration : IEntityTypeConfiguration<RedeemedCoupon>
    {
        public void Configure(EntityTypeBuilder<RedeemedCoupon> redeemedCouponConfiguration)
        {
            redeemedCouponConfiguration
                    .HasOne<Coupon>(redeemedCoupon => redeemedCoupon.Coupon)
                    .WithMany()
                    .IsRequired(true)
                    .HasForeignKey(redeemedCoupon => redeemedCoupon.CouponId)
                    .OnDelete(DeleteBehavior.Cascade);

            redeemedCouponConfiguration
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}
