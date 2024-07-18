namespace MobilePhoneWebApp.DataAccess.Entity
{
    public class OnlineStore
    {
        public int Id { get; set; }
        public string WebSite { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        
    }
}
