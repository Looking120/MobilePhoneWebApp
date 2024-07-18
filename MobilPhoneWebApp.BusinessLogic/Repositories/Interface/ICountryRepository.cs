using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface ICountryRepository
    {
        Task<List<Country>?> GetAllAsync();
        Task<Country> GetByIdAsync(int id);
        Task<Country> AddAsync(Country country);
        Task<Country> UpdateAsync(Country country);
        Task<Country> DeleteAsync(Country country);
    }
}
