using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City> GetByIdAsync(int id);
        Task<City> AddAsync(City city);
        Task<City> UpdateAsync(City city);
        Task<City> DeleteAsync(City city);
    }
}
