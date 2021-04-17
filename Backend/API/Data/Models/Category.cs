using System.Collections.Generic;

namespace API.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public ICollection<Task> Task { get; internal set; }
    }
}