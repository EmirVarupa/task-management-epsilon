using API.Data.Models;
using API.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityService _service;

        public PriorityController(IPriorityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrioritiesAsync()
        {
            var result = await _service.GetPrioritiesAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPriorityAsync([FromBody] Priority priority)
        {
            await _service.AddPriorityAsync(priority);

            return StatusCode(201);
        }
    }
}
