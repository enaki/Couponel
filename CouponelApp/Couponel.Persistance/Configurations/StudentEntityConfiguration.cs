using Couponel.Entities.Coupons;
using Couponel.Entities.Identities;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Entities.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Persistence.Configurations
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> studentConfiguration)
        {
            studentConfiguration
                .HasMany<RedeemedCoupon>(student => student.RedeemedCoupons)
                .WithOne()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            studentConfiguration
                .HasOne<User>(student => student.User)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey<Student>(student => student.Id)
                .OnDelete(DeleteBehavior.Cascade);

            studentConfiguration
                .Property(c => c.Id)
                .IsRequired();
        }
    }
}
