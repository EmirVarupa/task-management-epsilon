using API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Repos
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task AddUserAsync(User user);

        Task<bool> UpdateUserAsync(int id, User user);
    }
}