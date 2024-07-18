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
using System.Xml.Serialization;

namespace MobilePhoneWebApp.BusinessLogic.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        public SaleService(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }
        public async Task<SaleDto> AddAsync(SaleDto saleDto)
        {
            var saleRetuned = await _saleRepository.AddAsync(_mapper.Map<Sale>(saleDto));

            return _mapper.Map<SaleDto>(saleRetuned);
        }

        public async Task<SaleDto> DeleteAsync(int id)
        {
            var saleLooked = await _saleRepository.GetByIdAsync(id);
            if (saleLooked is null)
            {
                throw new NotFoundException("this sale does not exist");
            }
            var saleDeleted = await _saleRepository.DeleteAsync(_mapper.Map<Sale>(saleLooked));

            return _mapper.Map<SaleDto>(saleDeleted);
        }

        public async Task<List<SaleDto>> GetAllAsync()
        {
            var sales = await _saleRepository.GetAllAsync();
            if (sales is  null)
            {
                throw new NotFoundException("there us no sales");
            }

            return _mapper.Map<List<SaleDto>>(sales);
        }

        public async Task<SaleDto> GetByIdAsync(int id)
        {
            var saleLooked = await _saleRepository.GetByIdAsync(id);
            if (saleLooked is null)
            {
                throw new NotFoundException("this sale does not exist");
            }

            return _mapper.Map<SaleDto>(saleLooked);
        }

        public async Task<SaleDto> UpdateAsync(SaleDto saleDto)
        {
            var saleLooked = await _saleRepository.GetByIdAsync(saleDto.Id);
            if (saleLooked is null)
            {
                throw new NotFoundException("the sale is not exist");
            }
            _mapper.Map(saleDto, saleLooked);
            await _saleRepository.UpdateAsync(saleLooked);

            return saleDto;
        }
        public async Task<List<string>> GetOnlineStoreSalesByTime(DateTime startTime, DateTime endTime,int onlineStoreId) 
        {
            var sales = await _saleRepository.GetAllAsync();
            var returnedSales = sales.Where(s =>s.DateSale>=startTime&& s.DateSale<=endTime)
                                     .Where(s =>s.OnlineStores.Id == onlineStoreId).
                                      Select(s => $"{s.Customer.LastName}     ,      {s.Quantity}")
                                     .ToList();
            return returnedSales;
                   
        }
        public async Task<List<string>> GetStoreSalesByTime(DateTime startTime, DateTime endTime,int storeId)
        {
            var sales = await _saleRepository.GetAllAsync();
            var returnedSales = sales.Where(s => s.DateSale >= startTime && s.DateSale <= endTime)
                                     .Where(s => s.StoreId == storeId).
                                      Select(s => $"{s.Customer.LastName}     ,      {s.Quantity}")
                                     .ToList();
            return returnedSales;
        }
        public async Task<List<string>> GetSalesForEachCity(int cityId) 
        {
            var sales = await _saleRepository.GetAllAsync();
            var returnedSales = sales.Where(c => c.Store.CityId == cityId).
                                      Select(s => $"{s.Store.Name},{s.DateSale.ToString("dd/MM/yyyy")},{s.Customer.LastName}")
                                     .ToList();
            return returnedSales;
        }
        public async Task<string> GetTheMostPopularPhoneByCity(int cityId) 
        {
            var sales = await _saleRepository.GetAllAsync();
            var popularPhone = sales.Where(c => c.Store.CityId==cityId)
                                    .GroupBy(p =>p.MobilePhone.Model)
                                    .OrderByDescending(group => group.Count())
                                    .Select(group => group.Key)
                                    .FirstOrDefault();

            return popularPhone;

        }
        public async Task<string> GetTheMostUnPopularPhoneByCity(int cityId) 
        {
            var sales = await _saleRepository.GetAllAsync();
            var UnpopularPhone = sales.Where(c => c.Store.CityId == cityId)
                                    .GroupBy(p => p.MobilePhone.Model)
                                    .OrderByDescending(group => group.Min(s=>s.MobilePhone.Model))
                                    .Select(group => group.Key)
                                    .FirstOrDefault();

            return UnpopularPhone;
        }

       
    }
}
