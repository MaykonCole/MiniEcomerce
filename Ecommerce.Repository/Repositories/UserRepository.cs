using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ApiRepository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public UserRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> AddUserAsync(User user)
        {
            var userExists = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(user.Email));
            if (userExists != null)
                throw new Exception("User with email " + user.Email + " is already registered.");
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> DesactiveUserAsync(Guid id)
        {
            var user = await GetUserById(id);
            if (user.Active == true)
            {
                user.Active = false;
                user.DesactiveAt = DateTime.Now;
                await _dbContext.SaveChangesAsync();
            }
            return false;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var userByEmail = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
            return userByEmail;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var userById = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
            if (userById == null)
                throw new Exception("User not found with ID : " + id);
            return userById;
        }

        public async Task<List<User>> GetUsersByNameAsync(string name)
        {
            var userByName = await _dbContext.Users.Where(x => x.Name.Contains(name)).ToListAsync();
            return userByName;
        }

        public async Task<User> TakeLoginAsync(string email, string password)
        {
            var userToLogin = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
            return userToLogin;
        }

        public async Task<Guid> UpdateUserAsync(Guid id, string name, string password, bool notifyDescont)
        {
            var user = await GetUserById(id);
            user.Name = string.IsNullOrEmpty(name) ? user.Name : name;
            user.Password = string.IsNullOrEmpty(password) ? user.Password : password;
            user.Active = true;
            user.NotifyDescont = notifyDescont;
            user.UpdateAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }
    }
}
