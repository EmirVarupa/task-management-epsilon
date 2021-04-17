using API.Data.Dtos.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<Models.Task>> GetTasksAsync(bool? active, int loadCount);

        Task<IEnumerable<Models.Task>> GetArchivedTasksAsync(bool? active, int loadCount);
        
        Task AddTaskAsync(TaskCreateDto taskCreateDto);

        Task<TaskReadDto> GetTaskByIdAsync(int id);

        Task<bool> UpdateTaskByIdAsync(int id, TaskUpdateDto taskUpdateDto);

        Task<IEnumerable<Models.Task>> GetTaskByUserIdAsync(bool? active, int loadCount, int id);

        Task<IEnumerable<Models.Task>> GetImportantTasksByPriorityIdAsync(bool? active, int loadCount, int id);
    }
}