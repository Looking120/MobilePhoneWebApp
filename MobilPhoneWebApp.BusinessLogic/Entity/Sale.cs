using System.ComponentModel.DataAnnotations.Schema;

namespace MobilePhoneWebApp.DataAccess.Entity
{
    public class Sale
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public DateTime DateSale { get; set; }
        public int OnlineStoreId { get; set; }  
        public OnlineStore? OnlineStores { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public string ?Name { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public  int MobilePhoneId { get; set; }
        public MobilePhone MobilePhone { get; set;}
       
    }
}
