using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VRICODE.Models;

namespace VRICODE.Data.Mapping
{
    public class ProblemUserMap : IEntityTypeConfiguration<ProblemUser>
    {
        public void Configure(EntityTypeBuilder<ProblemUser> builder)
        {
            builder.HasKey(m => new { m.NidProblem, m.NidUser });

            builder.HasOne(m => m.Problem);
            builder.HasOne(m => m.User);
        }
    }
}
