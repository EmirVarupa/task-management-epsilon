using API.Data.EntityConfig;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Task = API.Data.Models.Task;

namespace API.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig()).SeedCategory();
            modelBuilder.ApplyConfiguration(new PriorityConfig()).SeedPriority();
            modelBuilder.ApplyConfiguration(new UserConfig()).SeedUser();

            base.OnModelCreating(modelBuilder);
        }
    }
}