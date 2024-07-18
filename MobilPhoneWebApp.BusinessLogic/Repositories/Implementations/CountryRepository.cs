using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DbContextWeb _db;

        public CountryRepository(DbContextWeb db)
        {
            _db = db;
        }

        public async Task<List<Country>?> GetAllAsync()
        {
            return await _db.Countries.AsNoTracking().ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _db.Countries.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Country> AddAsync(Country country)
        {
            _db.Countries.Add(country);
            await _db.SaveChangesAsync();
            return country;
        }

        public async Task<Country> UpdateAsync(Country country)
        {
            _db.Countries.Update(country);
            await _db.SaveChangesAsync();
            return country;
        }

        public async Task<Country> DeleteAsync(Country country)
        {
            _db?.Countries.Remove(country);
            await _db.SaveChangesAsync();
            return country;
        }
    }
}
