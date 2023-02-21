using AutoMapper;
using WebAPI.Dominio;
using WebAPI.Identity.Dto;

namespace WebAPI.Identity.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
