using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VRICODE.Models;

namespace VRICODE.Data.Mapping
{
    public class ProblemTestMap : IEntityTypeConfiguration<ProblemTest>
    {
        public void Configure(EntityTypeBuilder<ProblemTest> builder)
        {
            builder.HasKey(m => m.NidProblemTest);

            builder.HasOne(m => m.Problem);

            builder.Property(m => m.DesTestInput).HasMaxLength(512);
            builder.Property(m => m.DesTestExpectedOutput).HasMaxLength(512);
        }
    }
}
