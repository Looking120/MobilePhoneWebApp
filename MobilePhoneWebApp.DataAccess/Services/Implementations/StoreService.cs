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
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<StoreDto> AddAsync(StoreDto storeDto)
        {
            var storeRetuned = await _storeRepository.AddAsync(_mapper.Map<Store>(storeDto));

            return _mapper.Map<StoreDto>(storeRetuned);
        }

        public async Task<StoreDto> DeleteAsync(int id)
        {
            var storeLooked = await _storeRepository.GetByIdAsync(id);
            if (storeLooked is null)
            {
                throw new NotFoundException("this Store does not exist");
            }
            var storeDeleted = await _storeRepository.DeleteAsync(_mapper.Map<Store>(storeLooked));

            return _mapper.Map<StoreDto>(storeDeleted);
        }

        public async Task<List<StoreDto>> GetAllAsync()
        {
            var stores = await _storeRepository.GetAllAsync();
            if (stores is  null)
            {
                throw new NotFoundException("there us no stores");
            }

            return _mapper.Map<List<StoreDto>>(stores);
        }

        public async Task<StoreDto> GetByIdAsync(int id)
        {
            var storeLooked = await _storeRepository.GetByIdAsync(id);
            if (storeLooked is null)
            {
                throw new NotFoundException("this Store does not exist");
            }

            return _mapper.Map<StoreDto>(storeLooked);
        }

        public async Task<StoreDto> UpdateAsync(StoreDto storeDto)
        {
            var storeLooked = await _storeRepository.GetByIdAsync(storeDto.Id);
            if (storeLooked is null)
            {
                throw new NotFoundException("the Store is not exist");
            }
            _mapper.Map(storeDto, storeLooked);
            await _storeRepository.UpdateAsync(storeLooked);

            return storeDto;
        }
    }
}
