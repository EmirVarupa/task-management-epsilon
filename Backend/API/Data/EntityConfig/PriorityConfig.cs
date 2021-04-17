using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig
{
    public class PriorityConfig : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.HasKey(p => p.PriorityId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
