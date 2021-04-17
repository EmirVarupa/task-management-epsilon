using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos.User
{
    public class UserCreateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
