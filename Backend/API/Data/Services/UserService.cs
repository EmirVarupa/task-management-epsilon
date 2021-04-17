using API.Data.Dtos.User;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _repo.GetUsersAsync();
        }

        public async Task AddUserAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);

            await _repo.AddUserAsync(user);
        }

        public async Task<UserReadDto> GetUserByIdAsync(int id)
        {
            var userFromRepo = await _repo.GetUserByIdAsync(id);

            return _mapper.Map<UserReadDto>(userFromRepo);
        }

        public async Task<bool> UpdateUserByIdAsync(int id, UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);

            return await _repo.UpdateUserAsync(id, user);
        }
    }
}