﻿using AutoMapper;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Profiles
{
    public class PlayerTeamProfile : Profile
    {

        public PlayerTeamProfile()
        {
            CreateMap<PlayerTeam, PlayerTeamReadDto>();

            CreateMap<PlayerTeamCreateDto, PlayerTeam>()
                .ForMember(x => x.Drivers,
                    opt => opt.MapFrom(src => src.Drivers));
        }
    }
}
