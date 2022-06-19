using AutoMapper;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Profiles
{
    public class ScuderiaProfile : Profile
    {

        public ScuderiaProfile()
        {
            CreateMap<Scuderia, ScuderiaReadDto>();
            CreateMap<string, Scuderia>()
                .ForMember(x => x.XFIA_Code,
                    opt => opt.MapFrom(src => src));
        }
    }
}
