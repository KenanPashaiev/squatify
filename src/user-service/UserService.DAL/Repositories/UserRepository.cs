using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Core;
using UserService.DAL.Abstractions;

namespace UserService.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext applicationContext;

        public UserRepository(UserContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await applicationContext.Users.
                SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await applicationContext.Users.
                SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByNameCodeAsync(string username, string usercode)
        {
            return await applicationContext.Users.
                SingleOrDefaultAsync(u => u.Username == username && u.Usercode == usercode);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await applicationContext.Users.ToArrayAsync();
        }

        public async Task<User> AddUserAsync(User entity)
        {
            var user = await applicationContext.Users.AddAsync(entity);
            applicationContext.SaveChanges();
            return await GetUserAsync(user.Entity.Id);
        }

        public async Task<User> UpdateUserAsync(Guid id, User entity)
        {
            var user = await applicationContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            user.Username = entity.Username;
            applicationContext.SaveChanges();
            return user;
        }

        public async Task<User> DeleteUserAsync(Guid id)
        {
            var user = await GetUserAsync(id);
            applicationContext.Users.Remove(user);
            applicationContext.SaveChanges();
            return user;
        }
    }
}
