using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(int id);
        Task<CityDto> AddAsync(CityDto cityDto);
        Task<CityDto> UpdateAsync(CityDto cityDto);
        Task<CityDto> DeleteAsync(int id);
    }
}
