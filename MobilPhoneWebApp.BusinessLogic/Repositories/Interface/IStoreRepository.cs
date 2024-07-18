using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetAllAsync();
        Task<Store> GetByIdAsync(int id);
        Task<Store> AddAsync(Store store);
        Task<Store> UpdateAsync(Store store);
        Task<Store> DeleteAsync(Store store);
    }
}
