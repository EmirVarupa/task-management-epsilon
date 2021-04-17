using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly TaskContext _context;

        public CategoryRepo(TaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var categoryFromDb = await _context.Categories
                .SingleOrDefaultAsync(c => c.CategoryId == id);

            return categoryFromDb;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            var categoryFromDb = await GetCategoryByIdAsync(id);

            if(categoryFromDb == null)
            {
                return false;
            }

            categoryFromDb.Title = category.Title;

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}