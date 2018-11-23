using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRICODE.Models;

namespace VRICODE.Data.Mapping
{
    public class ProblemMap : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.HasKey(m => m.NidProblem);

            builder.Property(m => m.DesTitle).HasMaxLength(60);
            builder.Property(m => m.DesProblem).HasMaxLength(4096);
        }
    }
}
