using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface ITypeCPUService
    {
        Task<List<TypeCPUDto>> GetAllAsync();
        Task<TypeCPUDto> GetByIdAsync(int id);
        Task<TypeCPUDto> AddAsync(TypeCPUDto typeCPUDto);
        Task<TypeCPUDto> UpdateAsync(TypeCPUDto typeCPUDto);
        Task<TypeCPUDto> DeleteAsync(int id);
    }
}
