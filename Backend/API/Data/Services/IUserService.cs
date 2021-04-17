using API.Data.Dtos.User;
using API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task AddUserAsync(UserCreateDto user);

        Task<UserReadDto> GetUserByIdAsync(int id);

        Task<bool> UpdateUserByIdAsync(int id, UserUpdateDto userUpdateDto);
    }
}