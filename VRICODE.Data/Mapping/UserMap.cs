using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VRICODE.Models;

namespace VRICODE.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.NidUser);

            builder.Property(m => m.DesEmail).HasMaxLength(256);
            builder.Property(m => m.DesPassword).HasMaxLength(256);
        }
    }
}
