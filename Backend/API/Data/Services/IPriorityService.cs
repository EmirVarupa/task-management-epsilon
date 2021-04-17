using API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Services
{
    public interface IPriorityService
    {
        Task<IEnumerable<Priority>> GetPrioritiesAsync();

        Task AddPriorityAsync(Priority todoCategory);
    }
}
