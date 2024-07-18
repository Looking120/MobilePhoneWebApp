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
    public class ManufactureService : IManufactureService
    {

        private readonly IManufactureRepository _manufactureRepository;
        private readonly IMapper _mapper;
        public ManufactureService(IManufactureRepository manufactureRepository, IMapper mapper)
        {
            _manufactureRepository = manufactureRepository;
            _mapper = mapper;
        }
        public async Task<ManufactureDto> AddAsync(ManufactureDto manufactureDto)
        {
            var manufactureRetuned = await _manufactureRepository.AddAsync(_mapper.Map<Manufacture>(manufactureDto));

            return _mapper.Map<ManufactureDto>(manufactureRetuned); 
        }

        public async Task<ManufactureDto> DeleteAsync(int id)
        {
            var manufactureLooked = await _manufactureRepository.GetByIdAsync(id);
            if (manufactureLooked is null)
            {
                throw new NotFoundException("this manufacture does not exist"); ;
            }
            var manufactureDeleted = await _manufactureRepository.DeleteAsync(_mapper.Map<Manufacture>(manufactureLooked));

            return _mapper.Map<ManufactureDto>(manufactureDeleted);
        }

        public async Task<List<ManufactureDto>> GetAllAsync()
        {
            var manufactures = await _manufactureRepository.GetAllAsync();  
            if (manufactures is  null)
            {
                throw new NotFoundException("there is no manufacture");
            }
            return _mapper.Map<List<ManufactureDto>>(manufactures);
        }

        public async Task<ManufactureDto> GetByIdAsync(int id)
        {
            var countryLooked = await _manufactureRepository.GetByIdAsync(id);
            if (countryLooked is null)
            {
                throw new NotFoundException("this manufacture does not exist"); ;
            }

            return _mapper.Map<ManufactureDto>(countryLooked);
        }

        public  async Task<ManufactureDto> UpdateAsync(ManufactureDto manufactureDto)
        {
            var manufactureLooked = await _manufactureRepository.GetByIdAsync(manufactureDto.Id);
            if (manufactureLooked is null)
            {
                throw new NotFoundException("this manufacture does not exist"); ;
            }
            _mapper.Map<ManufactureDto>(manufactureLooked);
            await _manufactureRepository.UpdateAsync(manufactureLooked);

            return manufactureDto;
        }
    }
}
