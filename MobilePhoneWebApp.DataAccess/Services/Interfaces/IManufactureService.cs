using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface IManufactureService
    {
        Task<List<ManufactureDto>> GetAllAsync();
        Task<ManufactureDto> GetByIdAsync(int id);
        Task<ManufactureDto> AddAsync(ManufactureDto manufactureDto);
        Task<ManufactureDto> UpdateAsync(ManufactureDto manufactureDto);
        Task<ManufactureDto> DeleteAsync(int id);
    }
}
