using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface IOnlineStoreRepository
    {
        Task<List<OnlineStore>> GetAllAsync();
        Task<OnlineStore> GetByIdAsync(int id);
        Task<OnlineStore> AddAsync(OnlineStore onlineStore);
        Task<OnlineStore> UpdateAsync(OnlineStore onlineStore);
        Task<OnlineStore> DeleteAsync(OnlineStore onlineStore);
    }
}
