using System.Collections.Generic;

namespace API.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Task> Task { get; internal set; }
    }
}