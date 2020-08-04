using Couponel.Entities.Coupons;
using Couponel.Entities.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
