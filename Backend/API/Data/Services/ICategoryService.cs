using API.Data.Dtos.Category;
using API.Data.Dtos.Task;
using API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<CategoryReadDto> GetCategoryByIdAsync(int id);

        Task AddCategoryAsync(CategoryCreateDto categoryCreateDto);

        Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto categoryUpdateDto);
    }
}