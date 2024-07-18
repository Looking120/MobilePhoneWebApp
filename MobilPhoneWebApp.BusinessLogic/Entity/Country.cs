namespace MobilePhoneWebApp.DataAccess.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Manufacture>? Manufactures {  get; set; }
    }
}
