using System.Collections.Generic;

namespace API.Data.Models
{
    public class Priority
    {
        public int PriorityId { get; set; }

        public string Name { get; set; }

        public ICollection<Task> Task { get; internal set; }
    }
}
