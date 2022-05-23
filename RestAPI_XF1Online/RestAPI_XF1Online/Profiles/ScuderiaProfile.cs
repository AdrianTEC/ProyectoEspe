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
            CreateMap<int, Scuderia>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(src => src));
        }
    }
}
