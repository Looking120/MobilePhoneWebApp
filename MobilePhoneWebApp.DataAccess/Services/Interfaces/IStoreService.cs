using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface IStoreService
    {
        Task<List<StoreDto>> GetAllAsync();
        Task<StoreDto> GetByIdAsync(int id);
        Task<StoreDto> AddAsync(StoreDto storeDto);
        Task<StoreDto> UpdateAsync(StoreDto storeDto);
        Task<StoreDto> DeleteAsync(int id);
    }
}
