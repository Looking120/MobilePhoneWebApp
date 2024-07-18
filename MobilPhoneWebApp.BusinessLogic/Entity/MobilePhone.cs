namespace MobilePhoneWebApp.DataAccess.Entity
{
    public class MobilePhone
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public double Cost { get; set; }
        public DateTime YearOfRelease { get; set; }
        public double Ram { get; set; }
        public int CPUId { get; set; }
        public CPU? CPU { get; set; }
        public int ManufactureId { get; set; }    
        public Manufacture? Manufacture { get; set; }
        List<Sale> Sales { get; set; } 
    }
}
