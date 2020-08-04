using Couponel.Entities.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Persistence.Configurations
{
    class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> addressConfiguration)
        {
            addressConfiguration
                .ToTable("Addresses");

            addressConfiguration
                .Property<int>("Id")
                .IsRequired();

            addressConfiguration
                .HasKey("Id");
        }
    }
}
