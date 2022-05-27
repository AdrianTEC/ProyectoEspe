using AutoMapper;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Profiles
{
    public class LoginProfile : Profile
    {

        public LoginProfile()
        {
            CreateMap<Login, LoginReadDto>();
            CreateMap<LoginCreateDto, Login>();
        }
    }
}
