using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Repos
{
    public interface ITaskRepo
    {
        Task<IEnumerable<Models.Task>> GetTasksAsync(bool? active, int loadCount);

        Task<IEnumerable<Models.Task>> GetArchivedTasksAsync(bool? active, int loadCount); 

        Task AddTaskAsync(Models.Task category);

        Task<Models.Task> GetTaskByIdAsync(int id);

        Task<bool> UpdateTaskByIdAsync(int id, Models.Task task);

        Task<IEnumerable<Models.Task>> GetTaskByUserIdAsync(bool? active, int loadCount, int id);

        Task<IEnumerable<Models.Task>> GetImportantTasksByPriorityIdAsync(bool? active, int loadCount, int id);
    }
}