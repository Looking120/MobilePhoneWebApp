using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface IOnlineStoreService
    {
        Task<List<OnlineStoreDto>> GetAllAsync();
        Task<OnlineStoreDto> GetByIdAsync(int id);
        Task<OnlineStoreDto> AddAsync(OnlineStoreDto onlineStoreDto);
        Task<OnlineStoreDto> UpdateAsync(OnlineStoreDto onlineStoreDto);
        Task<OnlineStoreDto> DeleteAsync(int id);
    }
}
