using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Repos
{
    public class PriorityRepo : IPriorityRepo
    {
        private readonly TaskContext _context;

        public PriorityRepo(TaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Priority>> GetPrioritiesAsync()
        {
            return await _context.Priorities.ToListAsync();                           
        }

        public async Task AddPriorityAsync(Priority priority)
        {
            await _context.Priorities.AddAsync(priority);
            await _context.SaveChangesAsync();
        }
    }
}
