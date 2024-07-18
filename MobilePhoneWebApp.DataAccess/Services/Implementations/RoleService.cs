using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Implementations;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> AddAsync(RoleDto roleDto)
        {
            var roleAdded = await _roleRepository.AddAsync(_mapper.Map<Role>(roleDto));

            return _mapper.Map<RoleDto>(roleAdded);
        }

        public async Task<RoleDto> DeleteAsync(int id)
        {
            var roleLooked = await _roleRepository.GetByIdAsync(id);
            if (roleLooked is null)
            {
                throw new NotFoundException("this role does not exist");
            }
            var roleDeleted = await _roleRepository.DeleteAsync(_mapper.Map<Role>(roleLooked));

            return _mapper.Map<RoleDto>(roleDeleted);
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var roleLooked = await _roleRepository.GetAllAsync();
            if (roleLooked is null)
            {
                throw new NotFoundException("there is no roles");
            }

            return _mapper.Map<List<RoleDto>>(roleLooked);
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var roleLooked = await _roleRepository.GetByIdAsync(id);
            if (roleLooked is null)
            {
                throw new NotFoundException("this role does not exist");
            }

            return _mapper.Map<RoleDto>(roleLooked);
        }

        public async Task<RoleDto> UpdateAsync(RoleDto roleDto)
        {
            var roleLooked = await _roleRepository.GetByIdAsync(roleDto.Id);
            if (roleLooked is null)
            {
                throw new NotFoundException("the role does not exist");
            }
            _mapper.Map(roleDto, roleLooked);
            await _roleRepository.UpdateAsync(roleLooked);

            return roleDto;
        }
    }
}
