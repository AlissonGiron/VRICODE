using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRICODE.Models;

namespace VRICODE.Data.Mapping
{
    public class ProblemClassMap : IEntityTypeConfiguration<ProblemClass>
    {
        public void Configure(EntityTypeBuilder<ProblemClass> builder)
        {
            builder.HasKey(m => new { m.NidProblem, m.NidClass });
            builder.HasOne(m => m.Problem);
            builder.HasOne(m => m.Class);
        }
    }
}
