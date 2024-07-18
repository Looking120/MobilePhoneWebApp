using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Data;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.DataAccess.Repositories.Implementations
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DbContextWeb _db;
        public SaleRepository(DbContextWeb db)
        {
            _db = db;
        }
        public async Task<Sale> AddAsync(Sale sale)
        {
            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> DeleteAsync(Sale sale)
        {
            _db.Sales.Remove(sale);
            await _db.SaveChangesAsync();
            return sale;
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _db.Sales.
                Include(c => c.Customer)
                .Include(m => m.OnlineStores)
                .Include(s => s.Store)
                .Include(p => p.MobilePhone)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _db.Sales.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Sale> UpdateAsync(Sale sale)
        {
            _db.Sales.Update(sale);
            await _db.SaveChangesAsync();
            return sale;
        }
    }
}
