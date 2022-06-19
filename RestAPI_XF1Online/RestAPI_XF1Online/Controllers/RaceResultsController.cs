using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RaceResultsController : Controller
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public RaceResultsController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // POST: api/raceResults/
        [HttpPost]
        public ActionResult<IEnumerable<RaceResultReadDto>> CreateRace(IEnumerable<RaceResultCreateDto> raceResultCreateDtos)
        {
            var raceResultsModel = _mapper.Map<IEnumerable<RaceResult>>(raceResultCreateDtos);
            _repository.CreateRaceResult(raceResultsModel);
            _repository.SaveChanges();

            var raceResultReadDto = _mapper.Map<IEnumerable<RaceResultReadDto>>(raceResultsModel);

            return Ok(raceResultReadDto);
        }
    }
}
