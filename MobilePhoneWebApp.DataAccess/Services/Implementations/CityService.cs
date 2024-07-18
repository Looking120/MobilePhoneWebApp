using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.BusinessLogic.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public Task<CityDto> AddAsync(CityDto cityDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CityDto> DeleteAsync(int id)
        {
            var cityLooked = await _cityRepository.GetByIdAsync(id);

            if (cityLooked is null)
            {
                throw new NotFoundException("this City does not exist");
            }
            var cityDeleted = await _cityRepository.DeleteAsync(_mapper.Map<City>(cityLooked));

            return _mapper.Map<CityDto>(cityDeleted);
        }
        public async Task<List<CityDto>> GetAllAsync()
        {
            var cities = await _cityRepository.GetAllAsync();

            if (cities is null)
            {
                throw new NotFoundException("there us no cities");
            }

            return _mapper.Map<List<CityDto>>(cities);
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {
            var cityLooked = await _cityRepository.GetByIdAsync(id);
            if (cityLooked is null)
            {
                throw new NotFoundException("this City does not exist");
            }

            return _mapper.Map<CityDto>(cityLooked);
        }

        public async Task<CityDto> UpdateAsync(CityDto cityDto)
        {
            var cityLooked = await _cityRepository.GetByIdAsync(cityDto.Id);
            if (cityLooked is null)
            {
                throw new NotFoundException("the city is not exist");
            }
            _mapper.Map(cityDto, cityLooked);
            await _cityRepository.UpdateAsync(cityLooked);

            return cityDto;
        }
    }
}
