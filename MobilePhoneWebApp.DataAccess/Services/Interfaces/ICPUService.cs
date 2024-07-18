using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface ICPUService
    {
        Task<List<CPUDto>> GetAllAsync();
        Task<CPUDto> GetByIdAsync(int id);
        Task<CPUDto> AddAsync(CPUDto cpuDto);
        Task<CPUDto> UpdateAsync(CPUDto cpuDto);
        Task<CPUDto> DeleteAsync(int id);
    }
}
