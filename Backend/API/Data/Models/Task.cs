using System;

namespace API.Data.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool Active { get; set; }

        public bool Archived { get; set; }

        /// <summary>
        /// Category is FK in Task
        /// </summary>
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        /// <summary>
        /// PriorityId is FK in Task
        /// </summary>
        public int PriorityId { get; set; }

        public Priority Priority { get; set; }

        /// <summary>
        /// User is FK in Task
        /// </summary>
        public int UserId { get; set; }

        public User User { get; set; }

        public Task()
        {
            CreationDate = DateTime.Now.Date;
            Active = true;
            Archived = false;
        }
    }
}