using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextWeb _db;
        public UserRepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<User>AddUserAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<User>DeleteUserAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>>GetUserAllAsync()
        {
            return await _db.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User>GetUserByIdAsync(int Id)
        {
            return await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<User>UpdateUserAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return user;
        }
    }
}
