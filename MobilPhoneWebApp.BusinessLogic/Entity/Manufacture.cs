namespace MobilePhoneWebApp.DataAccess.Entity;

public class Manufacture
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<MobilePhone>? MobilePhones { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}
