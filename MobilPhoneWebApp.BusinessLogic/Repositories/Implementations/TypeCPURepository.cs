using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class TypeCPURepository : ITypeCPURepository
    {
        private readonly DbContextWeb _db;
        public TypeCPURepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<TypeCPU> AddAsync(TypeCPU typeCPU)
        {
            _db.TypeCPUs.Add(typeCPU);
            await _db.SaveChangesAsync();

            return typeCPU;
        }

        public async Task<TypeCPU> DeleteAsync(TypeCPU typeCPU)
        {
            _db.TypeCPUs.Remove(typeCPU);
            await _db.SaveChangesAsync();   
            return typeCPU; 
        }

        public async Task<List<TypeCPU>> GetAllAsync()
        {
            return await _db.TypeCPUs.AsNoTracking().ToListAsync();
        }

        public async Task<TypeCPU> GetByIdAsync(int id)
        {
            return await _db.TypeCPUs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TypeCPU> UpdateAsync(TypeCPU typeCPU)
        {
           _db.TypeCPUs.Update(typeCPU);
            await _db.SaveChangesAsync();
            return typeCPU; 
        }
    }
}
