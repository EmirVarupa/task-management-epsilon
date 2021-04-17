using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace API.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly TaskContext _context;

        public UserRepo(TaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var userFromDb = await _context.Users
                        .SingleOrDefaultAsync(u => u.UserId == id);

            return userFromDb;
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var userFromDb = await GetUserByIdAsync(id);

            if(userFromDb == null)
            {
                return false;
            }

            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}