using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Profiles
{
    public class OnlineStoreProfile : Profile
    {
        public OnlineStoreProfile()
        {
            CreateMap<OnlineStore, OnlineStoreDto>().ReverseMap();
        }
    }
}
