namespace MobilePhoneWebApp.DataAccess.Entity
{
    public class TypeCPU
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<CPU> CPUs { get; set;}
    }
}
