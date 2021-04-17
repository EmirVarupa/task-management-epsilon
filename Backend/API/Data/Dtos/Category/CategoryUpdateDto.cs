using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos.Category
{
    public class CategoryUpdateDto
    {
        [Required]
        public string Title { get; set; }
    }
}
