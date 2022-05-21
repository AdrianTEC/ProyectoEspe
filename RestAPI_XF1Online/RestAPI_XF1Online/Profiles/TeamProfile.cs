﻿using AutoMapper;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Profiles
{
    public class TeamProfile : Profile
    {

        public TeamProfile()
        {
            CreateMap<Team, TeamReadDto>();
            CreateMap<int, Team>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(src => src));
        }
    }
}
