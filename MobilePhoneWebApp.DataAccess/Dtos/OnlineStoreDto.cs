using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneWebApp.BusinessLogic.Dtos
{
    public class OnlineStoreDto
    {
        public int Id { get; set; }
        public string WebSite { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
