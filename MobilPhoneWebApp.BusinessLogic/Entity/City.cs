﻿namespace MobilePhoneWebApp.DataAccess.Entity
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Store> Stores { get; set;}
      
    }
}
