using AutoMapper;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Profiles
{
    public class RankingProfile : Profile
    {

        public RankingProfile()
        {
            CreateMap<Ranking, RankingReadDto>()
                .ForMember(x => x.PlayerUsername,
                    opt => opt.MapFrom(src => src.PlayerTeam.Player.Username))
                .ForMember(x => x.TeamName,
                    opt => opt.MapFrom(src => src.PlayerTeam.Name));
        }
    }
}
