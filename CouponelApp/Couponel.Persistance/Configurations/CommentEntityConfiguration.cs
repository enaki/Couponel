using Couponel.Entities.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Couponel.Persistence.Configurations
{
    public class CommentEntityConfiguration :IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> commentConfiguration)
        {
            commentConfiguration
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}
