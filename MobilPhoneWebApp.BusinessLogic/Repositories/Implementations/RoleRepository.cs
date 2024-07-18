using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContextWeb _db;
        public RoleRepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<Role> AddAsync(Role role)
        {
            _db.Roles.Add(role);
            await _db.SaveChangesAsync();

            return role;
        }

        public async Task<Role> DeleteAsync(Role role)
        {
            _db.Roles.Remove(role);
            await _db.SaveChangesAsync();

            return role;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _db.Roles.AsNoTracking().ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int Id)
        {
            return await _db.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            _db.Roles.Update(role);
            await _db.SaveChangesAsync();

            return role;
        }
    }
}
