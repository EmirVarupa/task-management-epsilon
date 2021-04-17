using API.Data.Dtos.Task;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskCreateDto, Task>();

            CreateMap<Task, TaskReadDto>();

            CreateMap<TaskUpdateDto, Task>();
        }
    }
}
