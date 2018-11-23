using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRICODE.Models;

namespace VRICODE.Data.Mapping
{
    public class ClassMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(m => m.NidClass);

            builder.Property(m => m.NamClass).HasMaxLength(60);
        }
    }
}
