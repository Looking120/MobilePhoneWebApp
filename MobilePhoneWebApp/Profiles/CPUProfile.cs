using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Profiles
{
   public class CPUProfile : Profile
   {
       public CPUProfile()
       {
           CreateMap<DataAccess.Entity.CPU, CPUDto>().ReverseMap();
       }
    }
    
}
