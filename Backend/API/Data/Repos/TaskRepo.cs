using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repos
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskContext _context;

        public TaskRepo(TaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Task>> GetTasksAsync(bool? active, int loadCount)
        {
            int rowsCount = 2;
            int startIndex = loadCount * rowsCount;

            if (active == null)
            {
                return await _context.Tasks
                    .Include(c => c.Category)
                    .Include(p => p.Priority)
                    .Include(u => u.User)
                    .Where(t => t.Archived == false)
                    .Skip(startIndex)
                    .Take(rowsCount)
                    .ToListAsync();
            }

            return await _context.Tasks
                .Include(c => c.Category)
                .Include(p => p.Priority)
                .Include(u => u.User)
                .Where(t => t.Archived == false)
                .Where(t => t.Active == active)
                .Skip(startIndex)
                .Take(rowsCount)
                .ToListAsync();
        }

        public async Task<IEnumerable<Models.Task>> GetArchivedTasksAsync(bool? active, int loadCount)
        {
            int rowsCount = 2;
            int startIndex = loadCount * rowsCount;

            if (active == null)
            {
                return await _context.Tasks
                    .Include(c => c.Category)
                    .Include(p => p.Priority)
                    .Include(u => u.User)
                    .Where(t => t.Archived == false)
                    .Skip(startIndex)
                    .Take(rowsCount)
                    .ToListAsync();
            }

            return await _context.Tasks
                .Include(c => c.Category)
                .Include(p => p.Priority)
                .Include(u => u.User)
                .Where(t => t.Archived == true)
                .Where(t => t.Active == active)
                .Skip(startIndex)
                .Take(rowsCount)
                .ToListAsync();
        }

        public async Task AddTaskAsync(Models.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Task> GetTaskByIdAsync(int id)
        {
            var taskFromDb = await _context.Tasks
            .Include(t => t.Category)
            .Include(t => t.Priority)
            .Include(t => t.User)
            .SingleOrDefaultAsync(t => t.TaskId == id);

            return taskFromDb;
        }

        public async Task<bool> UpdateTaskByIdAsync(int id, Models.Task task)
        {
            var taskFromDb = await GetTaskByIdAsync(id);

            if (taskFromDb == null)
            {
                return false;
            }

            taskFromDb.Title = task.Title;
            taskFromDb.Description = task.Description;
            taskFromDb.Active = task.Active;
            taskFromDb.PriorityId = task.PriorityId;
            taskFromDb.CategoryId = task.CategoryId;
            taskFromDb.UserId = task.UserId;
            taskFromDb.EndDate = task.EndDate;

            if (!taskFromDb.Archived && task.Archived)
            {
                taskFromDb.DeletedDate = DateTime.Now.Date;
                taskFromDb.Archived = true;
            } 
            else if(taskFromDb.Archived && !task.Archived)
            {               
                taskFromDb.Archived = false;
                taskFromDb.DeletedDate = null;
            }

            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<Models.Task>> GetTaskByUserIdAsync(bool? active, int loadCount, int id)
        {

            int rowsCount = 2;
            int startIndex = loadCount * rowsCount;

            if (active == null)
            {
                return await _context.Tasks
                    .Include(c => c.Category)
                    .Include(p => p.Priority)
                    .Include(u => u.User)
                    .Where(u => u.UserId == id)
                    .Skip(startIndex)
                    .Take(rowsCount)
                    .ToListAsync();
            }

            return await _context.Tasks
                .Include(c => c.Category)
                .Include(p => p.Priority)
                .Include(u => u.User)
                .Where(t => t.Archived == false)
                .Where(t => t.Active == active)
                .Where(u => u.UserId == id)
                .Skip(startIndex)
                .Take(rowsCount)
                .ToListAsync();
        }

        public async Task<IEnumerable<Models.Task>> GetImportantTasksByPriorityIdAsync(bool? active, int loadCount, int id)
        {

            int rowsCount = 2;
            int startIndex = loadCount * rowsCount;

            if (active == null)
            {
                return await _context.Tasks
                    .Include(c => c.Category)
                    .Include(p => p.Priority)
                    .Include(u => u.User)
                    .Where(p => p.PriorityId == id)
                    .Skip(startIndex)
                    .Take(rowsCount)
                    .ToListAsync();
            }

            return await _context.Tasks
                .Include(c => c.Category)
                .Include(p => p.Priority)
                .Include(u => u.User)
                .Where(t => t.Archived == false)
                .Where(t => t.Active == active)
                .Where(p => p.PriorityId == id)
                .Skip(startIndex)
                .Take(rowsCount)
                .ToListAsync();
        }
    }
}