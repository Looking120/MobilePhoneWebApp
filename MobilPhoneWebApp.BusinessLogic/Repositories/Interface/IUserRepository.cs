using MobilePhoneWebApp.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserAllAsync();
        Task<User> GetUserByIdAsync(int Id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(User user);
    }
}
