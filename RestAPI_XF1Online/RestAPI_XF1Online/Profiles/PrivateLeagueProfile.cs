using AutoMapper;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Profiles
{
    public class PrivateLeagueProfile : Profile
    {

        public PrivateLeagueProfile()
        {
            CreateMap<PrivateLeague, PrivateLeagueReadDto>();

            CreateMap<PrivateLeagueCreateDto, PrivateLeague>()
                .ForMember(x => x.Rankings,
                    opt => opt.MapFrom(src => new List<Ranking>()))
                .ForMember(x => x.InvitationCode,
                    opt => opt.MapFrom(src => -1))
                .ForMember(x => x.AmountOfParticipants,
                    opt => opt.MapFrom(src => -1));

            CreateMap<PrivateLeague, string>().ConvertUsing(src => src == null ? "" : src.Name);
        }
    }
}
