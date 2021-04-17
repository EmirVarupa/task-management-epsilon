using API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Repos
{
    public interface IPriorityRepo
    {
        Task<IEnumerable<Priority>> GetPrioritiesAsync();

        Task AddPriorityAsync(Priority priority);
    }
}
