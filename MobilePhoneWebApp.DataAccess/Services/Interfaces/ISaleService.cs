using MobilePhoneWebApp.BusinessLogic.Dtos;

namespace MobilePhoneWebApp.BusinessLogic.Services.Interfaces
{
    public interface ISaleService  
    {
        Task<List<SaleDto>> GetAllAsync();
        Task<SaleDto> GetByIdAsync(int id);
        Task<SaleDto> AddAsync(SaleDto saleDto);
        Task<SaleDto> UpdateAsync(SaleDto saleDto);
        Task<SaleDto> DeleteAsync(int id);
        Task<List<string>> GetOnlineStoreSalesByTime(DateTime startTime, DateTime endTime, int onlineStoreId);
        Task<List<string>> GetStoreSalesByTime(DateTime startTime, DateTime endTime, int storeId);
        Task<List<string>> GetSalesForEachCity(int cityId);
        Task<string> GetTheMostPopularPhoneByCity(int cityId);
        Task<string> GetTheMostUnPopularPhoneByCity(int cityId);
       
    }
 }
