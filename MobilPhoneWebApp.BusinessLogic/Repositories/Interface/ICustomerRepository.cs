using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.DataAccess.Repositories.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<Customer> DeleteAsync(Customer customer);
    }
}
