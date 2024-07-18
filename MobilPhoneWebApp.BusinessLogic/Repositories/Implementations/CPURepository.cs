using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class CPURepository : ICPURepository
    {
        private readonly DbContextWeb _db;
        public CPURepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<CPU> AddAsync(CPU cpu)
        {
            _db.CPUs.Add(cpu);
            await _db.SaveChangesAsync();
            return cpu;
        }

        public async Task<CPU> DeleteAsync(CPU cpu)
        {
            _db.CPUs.Remove(cpu);
            await _db.SaveChangesAsync();
            return cpu;
        }

        public async Task<List<CPU>> GetAllAsync()
        {
            return await _db.CPUs.AsNoTracking().ToListAsync();
        }

        public async Task<CPU> GetByIdAsync(int id)
        {
            return await _db.CPUs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CPU> UpdateAsync(CPU cpu)
        {
            _db.CPUs.Update(cpu);
            await _db.SaveChangesAsync();
            return cpu;
        }
    }
}
