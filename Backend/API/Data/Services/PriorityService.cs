using API.Data.Models;
using API.Data.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly IPriorityRepo _repo;

        public PriorityService(IPriorityRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Priority>> GetPrioritiesAsync()
        {
            return await _repo.GetPrioritiesAsync();
        }

        public async Task AddPriorityAsync(Priority priority)
        {
            await _repo.AddPriorityAsync(priority);
        }
    }
}
