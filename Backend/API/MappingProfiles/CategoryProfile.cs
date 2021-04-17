using API.Data.Dtos.Category;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<Category, CategoryReadDto>();

            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
