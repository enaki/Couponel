using Couponel.Entities.Coupons;
using Couponel.Entities.Identities;
using Couponel.Entities.Identities.UserTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Persistence.Configurations
{
    public class OffererEntityConfiguration : IEntityTypeConfiguration<Offerer>
    {
        public void Configure(EntityTypeBuilder<Offerer> offererConfiguration)
        {
            offererConfiguration
                .HasMany<Coupon>(offerer => offerer.Coupons)
                .WithOne()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            offererConfiguration
                .HasOne<User>(offerer => offerer.User)
                .WithOne()
                .IsRequired(true)
                .HasForeignKey<Offerer>(offerer => offerer.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            offererConfiguration
                .Property(c => c.Id)
                .IsRequired();
        }
    }
}
