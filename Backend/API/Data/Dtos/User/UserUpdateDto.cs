using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos.User
{
    public class UserUpdateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
