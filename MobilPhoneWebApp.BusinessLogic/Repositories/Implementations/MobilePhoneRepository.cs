using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class MobilePhoneRepository : IMobilePhoneRepository
    {
        private readonly DbContextWeb _db;
        public MobilePhoneRepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<MobilePhone> AddAsync(MobilePhone mobilePhone)
        {
            _db.MobilePhones.Add(mobilePhone);
            await _db.SaveChangesAsync();
            return mobilePhone;
        }

        public async Task<MobilePhone> DeleteAsync(MobilePhone mobilePhone)
        {
            _db.MobilePhones.Remove(mobilePhone);
            await _db.SaveChangesAsync();
            return mobilePhone;
        }

        public async Task<List<MobilePhone>> GetAllAsync()
        {
            return await _db.MobilePhones.AsNoTracking().ToListAsync();
        }

        public async Task<MobilePhone> GetByIdAsync(int id)
        {
            return await _db.MobilePhones.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MobilePhone> UpdateAsync(MobilePhone mobilePhone)
        {
            _db.MobilePhones.Update(mobilePhone);
            await _db.SaveChangesAsync();
            return mobilePhone;
        }
    }
}
