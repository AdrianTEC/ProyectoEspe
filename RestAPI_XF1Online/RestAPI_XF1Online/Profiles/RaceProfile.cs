using AutoMapper;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;
using System.Globalization;

namespace RestAPI_XF1Online.Profiles
{
    public class RaceProfile : Profile
    {
        private readonly IDataRepo _repository;

        public RaceProfile()
        {
            CreateMap<Race, RaceReadDto>()
                .ForMember(x => x.StartingDate,
                    opt => opt.MapFrom(src => ((DateTime)src.StartingDate).ToString("d/M/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.FinishingDate,
                    opt => opt.MapFrom(src => ((DateTime)src.FinishingDate).ToString("d/M/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.StartingTime,
                    opt => opt.MapFrom(src => ((DateTime)src.StartingTime).ToString("h:mm tt", CultureInfo.InvariantCulture)))
                .ForMember(x => x.FinishingTime,
                    opt => opt.MapFrom(src => ((DateTime)src.FinishingTime).ToString("h:mm tt", CultureInfo.InvariantCulture)));


            CreateMap<RaceCreateDto, Race>()
                .ForMember(x => x.StartingDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.StartingDate, "d/M/yyyy", DateTimeFormatInfo.CurrentInfo)))
                .ForMember(x => x.FinishingDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.FinishingDate, "d/M/yyyy", DateTimeFormatInfo.CurrentInfo)))
                .ForMember(x => x.StartingTime,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.StartingTime, "h:mm tt", CultureInfo.InvariantCulture)))
                .ForMember(x => x.FinishingTime,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.FinishingTime, "h:mm tt", CultureInfo.InvariantCulture)));
        }
    }
}
