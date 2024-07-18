using Microsoft.EntityFrameworkCore;
using MobilePhoneWebApp.DataAccess.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilePhoneWebApp.DataAccess.Data
{
    public class DbContextWeb : DbContext
    {
        public DbContextWeb(DbContextOptions options) : base(options)
        { }
      
        public DbSet<CPU> CPUs { get; set; }    
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<MobilePhone> MobilePhones { get; set; }
        public DbSet<OnlineStore> OnlineStores { get; set; }
        public DbSet<TypeCPU> TypeCPUs { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
       
        public DbSet<Manufacture> Manufactures { get; set; }


        
    }
}
