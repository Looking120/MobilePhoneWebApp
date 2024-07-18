using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface ICPURepository
    {
        Task<List<CPU>> GetAllAsync();
        Task<CPU> GetByIdAsync(int id);
        Task<CPU> AddAsync(CPU cpu);
        Task<CPU> UpdateAsync(CPU cpu);
        Task<CPU> DeleteAsync(CPU cpu);
    }
}
