using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(tc => tc.CategoryId);

            builder.Property(tc => tc.Title)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
