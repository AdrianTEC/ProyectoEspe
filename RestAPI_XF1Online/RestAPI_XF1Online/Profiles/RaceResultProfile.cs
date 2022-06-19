using AutoMapper;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Profiles
{
    public class RaceResultProfile : Profile
    {

        public RaceResultProfile()
        {
            CreateMap<RaceResult, RaceResultReadDto>();

            CreateMap<RaceResultCreateDto, RaceResult>();
        }
    }
}
