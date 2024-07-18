using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface IMobilePhoneService
    {
        Task<List<MobilePhoneDto>> GetAllAsync();
        Task<MobilePhoneDto> GetByIdAsync(int id);
        Task<MobilePhoneDto> AddAsync(MobilePhoneDto mobilePhoneDto);
        Task<MobilePhoneDto> UpdateAsync(MobilePhoneDto mobilePhoneDto);
        Task<MobilePhoneDto> DeleteAsync(int id);
    }
}
