using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, BusinessLogic.Dtos.CustomerDto>().ReverseMap();
        }
    }
}
