using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAllAsync();
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> AddAsync(Sale sale);
        Task<Sale> UpdateAsync(Sale sale);
        Task<Sale> DeleteAsync(Sale sale);
    }
}
