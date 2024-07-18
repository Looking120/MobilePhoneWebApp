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
    public class MobilePhoneService : IMobilePhoneService
    {

        private readonly IMobilePhoneRepository _mobilePhoneRepository;
        private readonly IMapper _mapper;
        public MobilePhoneService(IMobilePhoneRepository mobilePhoneRepository, IMapper mapper)
        {
            _mobilePhoneRepository = mobilePhoneRepository;
            _mapper = mapper;
        }
        public async Task<MobilePhoneDto> AddAsync(MobilePhoneDto mobilePhoneDto)
        {
            var mobilePhoneRetuned = await _mobilePhoneRepository.AddAsync(_mapper.Map<MobilePhone>(mobilePhoneDto));

            return _mapper.Map<MobilePhoneDto>(mobilePhoneRetuned);
        }

        public async Task<MobilePhoneDto> DeleteAsync(int id)
        {
            var mobilePhoneLooked = await _mobilePhoneRepository.GetByIdAsync(id);
            if (mobilePhoneLooked is null)
            {
                throw new NotFoundException("this Phone does not exist");
            }
            var mobilePhoneDeleted = await _mobilePhoneRepository.DeleteAsync(_mapper.Map<MobilePhone>(mobilePhoneLooked));

            return _mapper.Map<MobilePhoneDto>(mobilePhoneDeleted);
        }

        public async Task<List<MobilePhoneDto>> GetAllAsync()
        {
            var mobilePhones = await _mobilePhoneRepository.GetAllAsync();
            if (mobilePhones is  null)
            {
                throw new NotFoundException("there us no Phone");
            }

            return _mapper.Map<List<MobilePhoneDto>>(mobilePhones);
        }

        public async Task<MobilePhoneDto> GetByIdAsync(int id)
        {
            var mobilePhoneLooked = await _mobilePhoneRepository.GetByIdAsync(id);
            if (mobilePhoneLooked is null)
            {
                throw new NotFoundException("this Phone does not exist");
            }

            return _mapper.Map<MobilePhoneDto>(mobilePhoneLooked);
        }

        public async Task<MobilePhoneDto> UpdateAsync(MobilePhoneDto mobilePhoneDto)
        {
            var mobilePhoneLooked = await _mobilePhoneRepository.GetByIdAsync(mobilePhoneDto.Id);
            if (mobilePhoneLooked is null)
            {
                throw new NotFoundException("the Phone is not exist");
            }
            _mapper.Map(mobilePhoneDto, mobilePhoneLooked);
            await _mobilePhoneRepository.UpdateAsync(mobilePhoneLooked);

            return mobilePhoneDto;
        }
    }
}
