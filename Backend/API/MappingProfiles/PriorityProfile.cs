using API.Data.Dtos.PriorityDto;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles
{
    public class PriorityProfile : Profile
    {
        public PriorityProfile()
        {
            CreateMap<Priority, PriorityReadDto>();
        }
    }
}
