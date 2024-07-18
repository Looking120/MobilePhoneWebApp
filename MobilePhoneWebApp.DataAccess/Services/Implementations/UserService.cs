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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto>AddAsync(UserDto userDto)
        {
            var userAdded = await _userRepository.AddUserAsync(_mapper.Map<User>(userDto));

            return _mapper.Map<UserDto>(userAdded);
        }

        public async Task<UserDto>DeleteAsync(int id)
        {
            var userLooked = await _userRepository.GetUserByIdAsync(id);
            if (userLooked is null)
            {
                throw new NotFoundException("this user does not exist");
            }
            var userDeleted = await _userRepository.DeleteUserAsync(_mapper.Map<User>(userLooked));

            return _mapper.Map<UserDto>(userDeleted);
        }

        public async Task<List<UserDto>>GetAllAsync()
        {
            var userLooked = await _userRepository.GetUserAllAsync();
            if (userLooked is null)
            {
                throw new NotFoundException("there is no users");
            }

            return _mapper.Map<List<UserDto>>(userLooked);
        }

        public async Task<UserDto>GetByIdAsync(int id)
        {
            var userLooked = await _userRepository.GetUserByIdAsync(id);
            if (userLooked is null)
            {
                throw new NotFoundException("this user does not exist");
            }

            return _mapper.Map<UserDto>(userLooked);
        }

        public async Task<UserDto>UpdateAsync(UserDto userDto)
        {
            var userLooked = await _userRepository.GetUserByIdAsync(userDto.Id);
            if (userLooked is null)
            {
                throw new NotFoundException("the user does not exist");
            }
            _mapper.Map(userDto, userLooked);
            await _userRepository.UpdateUserAsync(userLooked);

            return userDto;
        }
    }
}
