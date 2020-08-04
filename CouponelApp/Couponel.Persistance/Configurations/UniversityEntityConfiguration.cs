using Couponel.Entities.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Persistence.Configurations
{
    public class UniversityEntityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> universityConfiguration)
        {
            universityConfiguration
                .HasMany<Faculty>(university => university.Faculties)
                .WithOne()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            universityConfiguration
                .Property(c => c.Id)
                .IsRequired();

            universityConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.City)
                    .IsRequired()
                    .HasColumnName("City");
            universityConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Country)
                    .IsRequired()
                    .HasColumnName("Country");
            universityConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Street)
                    .IsRequired()
                    .HasColumnName("Street");
            universityConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Number)
                    .IsRequired()
                    .HasColumnName("Number");
        }
    }
}
