using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = API.Data.Models.Task;

namespace API.Data.EntityConfig
{
    public class TaskConfig : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.TaskId);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Description)
                .IsRequired();

            builder.Property(t => t.Active)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(t => t.Archived)
                .IsRequired()
                .HasColumnType("bit");

            /* One to many relationship between Task and Category */
            builder.HasOne(c => c.Category)
                .WithMany(t => t.Task)
                .HasForeignKey(c => c.CategoryId);

            /* One to many relationship between Task and User */
            builder.HasOne(u => u.User)
                .WithMany(t => t.Task)
                .HasForeignKey(u => u.UserId);
        }
    }
}
