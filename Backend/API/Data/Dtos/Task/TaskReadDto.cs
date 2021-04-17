using API.Data.Dtos.Category;
using API.Data.Dtos.PriorityDto;
using API.Data.Dtos.User;
using System;

namespace API.Data.Dtos.Task
{
    public class TaskReadDto
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public bool Active { get; set; }

        public bool Archived { get; set; }

        public CategoryReadDto Category { get; set; }

        public PriorityReadDto Priority { get; set; }

        public UserReadDto User { get; set; }
    }
}
