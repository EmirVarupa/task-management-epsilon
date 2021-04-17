using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public static class DbContextExtentions
    {
        public static ModelBuilder SeedPriority(this ModelBuilder builder)
        {
            builder.Entity<Priority>().HasData(new Priority { PriorityId = 1, Name = "Low" });
            builder.Entity<Priority>().HasData(new Priority { PriorityId = 2, Name = "Medium" });
            builder.Entity<Priority>().HasData(new Priority { PriorityId = 3, Name = "High" });

            return builder;
        }

        public static ModelBuilder SeedCategory(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(new Category { CategoryId = 1, Title = "Work" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 2, Title = "Education" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 3, Title = "Uncategorized" });

            return builder;
        }

        public static ModelBuilder SeedUser(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User { UserId = 1, FirstName = "Ajna", LastName = "Fetic" });
            builder.Entity<User>().HasData(new User { UserId = 2, FirstName = "Harun", LastName = "Smaka" });
            builder.Entity<User>().HasData(new User { UserId = 3, FirstName = "Dzenan", LastName = "Bejdic" });
            builder.Entity<User>().HasData(new User { UserId = 4, FirstName = "Emir", LastName = "Varupa" });
            builder.Entity<User>().HasData(new User { UserId = 5, FirstName = "Adis", LastName = "Skender" });
            builder.Entity<User>().HasData(new User { UserId = 6, FirstName = "Hana", LastName = "Sehic" });

            return builder;
        }
    }
}
