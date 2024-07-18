using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface IManufactureRepository
    {
        Task<List<Manufacture>> GetAllAsync();
        Task<Manufacture> GetByIdAsync(int id);
        Task<Manufacture> AddAsync(Manufacture manufacture);
        Task<Manufacture> UpdateAsync(Manufacture manufacture);
        Task<Manufacture> DeleteAsync(Manufacture manufacture);
    }
}
