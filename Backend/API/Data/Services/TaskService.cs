using API.Data.Dtos.Task;
using API.Data.Repos;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo _repo;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Models.Task>> GetTasksAsync(bool? active, int loadCount)
        {
            return await _repo.GetTasksAsync(active, loadCount);
        }

        public async Task<IEnumerable<Models.Task>> GetArchivedTasksAsync(bool? active, int loadCount)
        {
            return await _repo.GetArchivedTasksAsync(active, loadCount);
        }

        public async Task AddTaskAsync(TaskCreateDto taskCreateDto)
        {
            var task = _mapper.Map<Models.Task>(taskCreateDto);

            await _repo.AddTaskAsync(task);
        }

        public async Task<TaskReadDto> GetTaskByIdAsync(int id)
        {
            var taskFromRepo = await _repo.GetTaskByIdAsync(id);

            return _mapper.Map<TaskReadDto>(taskFromRepo);
        }

        public async Task<bool> UpdateTaskByIdAsync(int id, TaskUpdateDto taskUpdateDto)
        {
            var task = _mapper.Map<Models.Task>(taskUpdateDto);


            return await _repo.UpdateTaskByIdAsync(id, task);
        }

        public async Task<IEnumerable<Models.Task>> GetTaskByUserIdAsync(bool? active, int loadCount, int id)
        {

            return await _repo.GetTaskByUserIdAsync(active, loadCount, id);
        }

        public async Task<IEnumerable<Models.Task>> GetImportantTasksByPriorityIdAsync(bool? active, int loadCount, int id)
        {

            return await _repo.GetImportantTasksByPriorityIdAsync(active, loadCount, id);
        }
    }
}