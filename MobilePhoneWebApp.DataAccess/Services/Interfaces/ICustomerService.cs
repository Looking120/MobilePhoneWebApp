using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int id);
        Task<CustomerDto> AddAsync(CustomerDto customerDto);
        Task<CustomerDto> UpdateAsync(CustomerDto customerDto);
        Task<CustomerDto> DeleteAsync(int id);
    }
}
