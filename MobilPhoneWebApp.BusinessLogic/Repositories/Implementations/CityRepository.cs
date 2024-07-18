using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{

    public class CityRepository : ICityRepository
    {
        private readonly DbContextWeb _db;
        public CityRepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<City> AddAsync(City city)
        {
            _db.Cities.Add(city);
            await _db.SaveChangesAsync();

            return city;
        }
        public async Task<City> DeleteAsync(City city)
        {
            _db.Cities.Remove(city);
            await _db.SaveChangesAsync();

            return city;
        }
        public async Task<List<City>> GetAllAsync()
        {
            return await _db.Cities.AsNoTracking().ToListAsync();
        }
        public async Task<City> GetByIdAsync(int id)
        {
            return await _db.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<City> UpdateAsync(City city)
        {
            _db.Cities.Update(city);
            await _db.SaveChangesAsync();

            return city;
        }
    }

}
