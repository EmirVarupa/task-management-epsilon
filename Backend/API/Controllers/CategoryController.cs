using API.Data.Dtos.Category;
using API.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var result = await _service.GetCategoriesAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryCreateDto categoryCreateDto)
        {
            await _service.AddCategoryAsync(categoryCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _service.UpdateCategoryAsync(id, categoryUpdateDto);

            if(!result)
            {
                return BadRequest("Update failed!");
            }

            return NoContent();
        }
    }
}