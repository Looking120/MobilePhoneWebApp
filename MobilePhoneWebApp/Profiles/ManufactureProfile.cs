using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Profiles
{
    public class ManufactureProfile : Profile
    {
        public ManufactureProfile()
        {
            CreateMap<Manufacture, ManufactureDto>().ReverseMap();
        }
    }
}
