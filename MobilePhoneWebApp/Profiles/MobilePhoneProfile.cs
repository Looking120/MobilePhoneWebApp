using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Profiles
{
    public class MobilePhoneProfile : Profile
    {
        public MobilePhoneProfile()
        {
            CreateMap<MobilePhone, MobilePhoneDto>().ReverseMap();
        }
    }
}
