using MobilePhoneWebApp.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Dtos
{
    public class MobilePhoneDto
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
        List<SaleDto> Sales { get; set; }

    }
}
