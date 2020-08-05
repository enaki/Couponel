using Couponel.Entities.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Couponel.Persistence.Configurations
{
    public class PhotoEntityConfiguration :IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> photoConfiguration)
        {
            photoConfiguration
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}
