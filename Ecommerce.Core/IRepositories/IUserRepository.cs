using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public interface IUserRepository
    {
        Task<User> TakeLoginAsync(string email, string password);
        Task<Guid> AddUserAsync(User user);
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<List<User>> GetUsersByNameAsync(string name);
        Task<User> GetUserByEmailAsync(string email);
        Task<Guid> UpdateUserAsync(Guid id, string name, string password, bool notifyDescont);
        Task<bool> DesactiveUserAsync(Guid id);
    }
}
