using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface IMobilePhoneRepository
    {
        Task<List<MobilePhone>> GetAllAsync();
        Task<MobilePhone> GetByIdAsync(int id);
        Task<MobilePhone> AddAsync(MobilePhone mobilePhone);
        Task<MobilePhone> UpdateAsync(MobilePhone mobilePhone);
        Task<MobilePhone> DeleteAsync(MobilePhone mobilePhone);
    }
}
