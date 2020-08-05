using Couponel.Entities.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.Identities;

namespace Couponel.Persistence.Configurations
{
    public class FacultyEntityConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> facultyConfiguration)
        {
            facultyConfiguration
                .HasMany<Student>(faculty => faculty.Students)
                .WithOne()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            facultyConfiguration
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            facultyConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.City)
                    .IsRequired()
                    .HasColumnName("City");
            facultyConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Country)
                    .IsRequired()
                    .HasColumnName("Country");
            facultyConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Street)
                    .IsRequired()
                    .HasColumnName("Street");
            facultyConfiguration.OwnsOne(e => e.Address)
                    .Property(a => a.Number)
                    .IsRequired()
                    .HasColumnName("Number");
        }
    }
}
