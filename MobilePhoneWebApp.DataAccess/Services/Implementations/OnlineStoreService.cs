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
    public class OnlineStoreService : IOnlineStoreService
    {
        private readonly IOnlineStoreRepository _onlineStoreRepository;
        private readonly IMapper _mapper;
        public OnlineStoreService(IOnlineStoreRepository onlineStoreRepository, IMapper mapper)
        {
            _onlineStoreRepository = onlineStoreRepository;
            _mapper = mapper;
        }
        public async Task<OnlineStoreDto> AddAsync(OnlineStoreDto onlineStoreDto)
        {
            var onlineStoreRetuned = await _onlineStoreRepository.AddAsync(_mapper.Map<OnlineStore>(onlineStoreDto));

            return _mapper.Map<OnlineStoreDto>(onlineStoreRetuned);
        }

        public async Task<OnlineStoreDto> DeleteAsync(int id)
        {
            var onlineStoreLooked = await _onlineStoreRepository.GetByIdAsync(id);
            if (onlineStoreLooked is null)
            {
                throw new NotFoundException("this OnlineStore does not exist");
            }
            var onlineStoreDeleted = await _onlineStoreRepository.DeleteAsync(_mapper.Map<OnlineStore>(onlineStoreLooked));

            return _mapper.Map<OnlineStoreDto>(onlineStoreDeleted);
        }

        public async Task<List<OnlineStoreDto>> GetAllAsync()
        {
            var onlineStores = await _onlineStoreRepository.GetAllAsync();
            if (onlineStores is  null)
            {
                throw new NotFoundException("there us no OnlineStore");
            }

            return _mapper.Map<List<OnlineStoreDto>>(onlineStores);
        }

            public async Task<OnlineStoreDto> GetByIdAsync(int id)
        {
            var onlineStoreLooked = await _onlineStoreRepository.GetByIdAsync(id);
            if (onlineStoreLooked is null)
            {
                throw new NotFoundException("this OnlineStore does not exist");
            }

            return _mapper.Map<OnlineStoreDto>(onlineStoreLooked);
        }

        public async Task<OnlineStoreDto> UpdateAsync(OnlineStoreDto onlineStoreDto)
        {
            var onlineStoreLooked = await _onlineStoreRepository.GetByIdAsync(onlineStoreDto.Id);
            if (onlineStoreLooked is null)
            {
                throw new NotFoundException("the OnlineStore is not exist");
            }
            _mapper.Map(onlineStoreDto, onlineStoreLooked);
            await _onlineStoreRepository.UpdateAsync(onlineStoreLooked);

            return onlineStoreDto;
        }
    }
}
