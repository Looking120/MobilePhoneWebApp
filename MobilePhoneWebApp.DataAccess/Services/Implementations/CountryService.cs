using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;
using MobilePhoneWebApp.DataAccess.Repositories.Interface;

namespace MobilePhoneWebApp.BusinessLogic.Services.Implementations
{
    public class CountryService : ICountryService
    {

        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<CountryDto> AddAsync(CountryDto countrytDto)
        {
            var countryRetuned = await _countryRepository.AddAsync(_mapper.Map<Country>(countrytDto));

            return _mapper.Map<CountryDto>(countryRetuned);
        }

        public async Task<CountryDto> DeleteAsync(int id)
        {
            var countryLooked = await _countryRepository.GetByIdAsync(id);
            if (countryLooked is null)
            {
                throw new NotFoundException("this country does not exist"); ;
            }
            var countryDeleted = await _countryRepository.DeleteAsync(_mapper.Map<Country>(countryLooked));

            return _mapper.Map<CountryDto>(countryDeleted);
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            var countries = await _countryRepository.GetAllAsync();
            if (countries is  null)
            {
                throw new NotFoundException("there is no countries");
            }

            return _mapper.Map<List<CountryDto>>(countries);
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            var countryLooked = await _countryRepository.GetByIdAsync(id);
            if (countryLooked is null)
            {
                throw new NotFoundException("this country does not exist"); ;
            }

            return _mapper.Map<CountryDto>(countryLooked);
        }

        public async Task<CountryDto> UpdateAsync(CountryDto countryDto)
        {
            var countryLooked = await _countryRepository.GetByIdAsync(countryDto.Id);
            if (countryLooked is null)
            {
                throw new NotFoundException("this country does not exist"); ;
            }
            _mapper.Map<CountryDto>(countryLooked);
            await _countryRepository.UpdateAsync(countryLooked);

            return countryDto;
        }
    }
}
