using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class ManufactureRepository : IManufactureRepository
    {
        private readonly DbContextWeb _db;
        public ManufactureRepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<Manufacture> AddAsync(Manufacture manufacture)
        {
            _db.Manufactures.Add(manufacture);
            await _db.SaveChangesAsync();
            return manufacture;
        }

        public async Task<Manufacture> DeleteAsync(Manufacture manufacture)
        {
            _db.Manufactures.Remove(manufacture);
            await _db.SaveChangesAsync();
            return manufacture;
        }

        public async Task<List<Manufacture>> GetAllAsync()
        {
            return await _db.Manufactures.AsNoTracking().ToListAsync();
        }

        public Task<Manufacture> GetByIdAsync(int id)
        {
            return _db.Manufactures.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Manufacture> UpdateAsync(Manufacture manufacture)
        {
            _db.Manufactures.Update(manufacture);
            await _db.SaveChangesAsync();
            return manufacture;
        }
    }
}
