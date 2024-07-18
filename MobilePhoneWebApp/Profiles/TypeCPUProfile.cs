using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Profiles
{
    public class TypeCPUProfile : Profile
    {
        public TypeCPUProfile()
        {
            CreateMap<TypeCPU, TypeCPUDto>().ReverseMap();
        }
    }
}
