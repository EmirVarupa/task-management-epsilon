using API.Data.Dtos.Task;
using API.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasksAsync(bool? active, int loadCount)
        {
            var result = await _service.GetTasksAsync(active, loadCount);

            return Ok(result);
        }

        [HttpGet]
        [Route("Archived")]
        public async Task<IActionResult> GetArchivedTasksAsync(bool? active, int loadCount)
        {
            var result = await _service.GetArchivedTasksAsync(active, loadCount);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(int id)
        {
            var task = await _service.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskAsync([FromBody] TaskCreateDto taskCreateDto)
        {
            await _service.AddTaskAsync(taskCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, [FromBody] TaskUpdateDto taskUpdateDto)
        {
            var result = await _service.UpdateTaskByIdAsync(id, taskUpdateDto);

            if (!result)
            {
                return BadRequest("Update failed!");
            }

            return NoContent();
        }

        [HttpGet("Assignee")]
        public async Task<IActionResult> GetTaskByUserIdAsync(bool? active, int loadCount, int id)
        {
            var result = await _service.GetTaskByUserIdAsync(active, loadCount, id);

            return Ok(result);
        }

        [HttpGet("Important")]
        public async Task<IActionResult> GetImportantTasksByPriorityIdAsync(bool? active, int loadCount, int PriorityId)
        {
            var result = await _service.GetImportantTasksByPriorityIdAsync(active, loadCount, PriorityId);

            return Ok(result);
        }
    }
}