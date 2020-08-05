using Couponel.Entities.Coupons;
using Couponel.Entities.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Persistence.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration
                .Property(c => c.Id)
                .IsRequired();

            userConfiguration
                .HasMany<Coupon>(user => user.Coupons)
                .WithOne()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            userConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.City)
                    .IsRequired()
                    .HasColumnName("City");
                    
            userConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Country)
                    .IsRequired()
                    .HasColumnName("Country");
            userConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Street)
                    .IsRequired()
                    .HasColumnName("Street");
            userConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Number)
                    .IsRequired()
                    .HasColumnName("Number");
        }
    }
}
