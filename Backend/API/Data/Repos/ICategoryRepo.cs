using API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Repos
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(int id);

        Task AddCategoryAsync(Category category);

        Task<bool> UpdateCategoryAsync(int id, Category category);
    }
}