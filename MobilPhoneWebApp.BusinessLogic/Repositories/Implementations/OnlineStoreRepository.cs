using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class OnlineStoreRepository : IOnlineStoreRepository
    {
        private readonly DbContextWeb _db;
        public OnlineStoreRepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<OnlineStore> AddAsync(OnlineStore onlineStore)
        {
            _db.OnlineStores.Add(onlineStore);
            await _db.SaveChangesAsync();
            return onlineStore;
        }

        public async Task<OnlineStore> DeleteAsync(OnlineStore onlineStore)
        {
            _db.OnlineStores.Remove(onlineStore);
            await _db.SaveChangesAsync();
            return onlineStore;
        }

        public async Task<List<OnlineStore>> GetAllAsync()
        {
            return await _db.OnlineStores.AsNoTracking().ToListAsync();
        }

        public async Task<OnlineStore> GetByIdAsync(int id)
        {
            return await _db.OnlineStores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OnlineStore> UpdateAsync(OnlineStore onlineStore)
        {
            _db.OnlineStores.Update(onlineStore);
            await _db.SaveChangesAsync();
            return onlineStore;
        }
    }
}
