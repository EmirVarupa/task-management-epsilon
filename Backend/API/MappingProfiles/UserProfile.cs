using API.Data.Dtos.User;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();

            CreateMap<User, UserReadDto>();

            CreateMap<UserUpdateDto, User>();
        }
    }
}
