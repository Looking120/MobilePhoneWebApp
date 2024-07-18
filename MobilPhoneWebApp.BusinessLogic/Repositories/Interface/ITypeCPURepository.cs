using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface ITypeCPURepository
    {
        Task<List<TypeCPU>> GetAllAsync();
        Task<TypeCPU> GetByIdAsync(int id);
        Task<TypeCPU> AddAsync(TypeCPU typeCPU);
        Task<TypeCPU> UpdateAsync(TypeCPU typeCPU);
        Task<TypeCPU> DeleteAsync(TypeCPU typeCPU);
    }
}
