using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDto>().ReverseMap();
        }
    }
}
