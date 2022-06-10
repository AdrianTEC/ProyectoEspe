using AutoMapper;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Profiles
{
    public class PlayerNotificationProfile : Profile
    {

        public PlayerNotificationProfile()
        {
            CreateMap<PlayerNotification, PlayerNotificationReadDto>();
        }
    }
}
