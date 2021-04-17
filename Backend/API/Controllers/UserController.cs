using API.Data.Dtos.User;
using API.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result =  await _service.GetUsersAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _service.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsersAsync([FromBody] UserCreateDto userCreateDto)
        {
            await _service.AddUserAsync(userCreateDto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _service.UpdateUserByIdAsync(id, userUpdateDto);

            if (!result)
            {
                return BadRequest("Update failed!");
            }

            return NoContent();
        }
    }
}