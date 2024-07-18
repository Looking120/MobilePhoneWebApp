using MobilePhoneWebApp.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PostalCode { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
