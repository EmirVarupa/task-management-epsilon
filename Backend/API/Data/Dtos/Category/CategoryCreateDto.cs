using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos.Category
{
    public class CategoryCreateDto
    {
        [Required]
        public string Title { get; set; }
    }
}
