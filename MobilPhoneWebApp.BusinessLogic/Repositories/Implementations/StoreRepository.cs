using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DbContextWeb _db;
        public StoreRepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<Store> AddAsync(Store store)
        {
            _db.Stores.Add(store);
            await _db.SaveChangesAsync();
            return store;
        }

        public async Task<Store> DeleteAsync(Store store)
        {
            _db.Stores.Remove(store);
            await _db.SaveChangesAsync();
            return store;
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await _db.Stores.Include(c =>c.City).AsNoTracking().ToListAsync();
        }

        public async Task<Store> GetByIdAsync(int id)
        {
            return await _db.Stores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Store> UpdateAsync(Store store)
        {
            _db.Stores.Update(store);
            await _db.SaveChangesAsync();
            return store;
        }
    }
}
