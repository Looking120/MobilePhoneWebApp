using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.BusinessLogic.Dtos
{
    public class SaleDto
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public DateTime DateSale { get; set; }
        public int OnlineStoreId { get; set; }
        public OnlineStore? OnlineStores { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public string? Name { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MobilePhoneId { get; set; }
        public MobilePhone MobilePhone { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //For solving Tasks
        public List<string> OnlineSales { get; set; }
        public List<string> StoreSales { get; set; }

        public List<string> CitySales { get; set; }

        public string MostPopularPhoneModel { get; set; }

        public string UnPopularPhoneModel { get; set; }


    }
}
