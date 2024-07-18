namespace MobilePhoneWebApp.DataAccess.Entity
{
    public class CPU
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TypeCPUId { get; set; }
        public TypeCPU TypeCPU { get; set; }
    }
}
