using MobilePhoneWebApp.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto> GetByIdAsync(int id);
        Task<RoleDto> AddAsync(RoleDto roleDto);
        Task<RoleDto> UpdateAsync(RoleDto roleDto);
        Task<RoleDto> DeleteAsync(int id);
    }
}
