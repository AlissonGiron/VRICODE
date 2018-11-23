using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VRICODE.Models;

namespace VRICODE.Data.Mapping
{
    public class UserClassMap : IEntityTypeConfiguration<UserClass>
    {
        public void Configure(EntityTypeBuilder<UserClass> builder)
        {
            builder.HasKey(m => new { m.NidUser, m.NidClass });

            builder.HasOne(m => m.User);
            builder.HasOne(m => m.Class);
        }
    }
}
