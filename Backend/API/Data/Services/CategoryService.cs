using API.Data.Dtos.Category;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _repo.GetCategoriesAsync();
        }

        public async Task<CategoryReadDto> GetCategoryByIdAsync(int id)
        {
            var category = await _repo.GetCategoryByIdAsync(id);

            if(category == null)
            {
                return null;
            }

            return _mapper.Map<CategoryReadDto>(category);
        }

        public async Task AddCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);

            await _repo.AddCategoryAsync(category);
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);

            return await _repo.UpdateCategoryAsync(id, category);
        }
    }
}