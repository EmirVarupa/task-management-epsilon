using System;
using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos.Task
{
    public class TaskCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int PriorityId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
