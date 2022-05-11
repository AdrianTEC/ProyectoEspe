using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RacesController : Controller
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public RacesController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/races/{championshipId}
        [HttpGet("byChampionship/{championshipId}", Name = "GetRacesByChampionshipId")]
        public ActionResult<IEnumerable<RaceReadDto>> GetRacesByChampionshipId(string championshipId)
        {
            var races = _repository.GetRacesByChampionshipId(championshipId);
            return Ok(_mapper.Map<IEnumerable<RaceReadDto>>(races));
        }

        // GET: api/races/{id}
        [HttpGet("{id}", Name = "GetRaceById")]
        public ActionResult<RaceReadDto> GetRaceById(int id)
        {
            var races = _repository.GetRaceById(id);
            return Ok(_mapper.Map<RaceReadDto>(races));
        }

        // GET: api/races/
        [HttpGet]
        public ActionResult<IEnumerable<RaceReadDto>> GetRaces()
        {
            var races = _repository.GetAllRaces();
            return Ok(_mapper.Map<IEnumerable<RaceReadDto>>(races));
        }

        // POST: api/races/
        [HttpPost]
        public ActionResult<RaceReadDto> CreateRace(RaceCreateDto raceCreateDto)
        {
            try
            {
                var raceModel = _mapper.Map<Race>(raceCreateDto);
                _repository.CreateRace(raceModel);
                _repository.SaveChanges();

                var raceReadDto = _mapper.Map<RaceReadDto>(raceModel);

                return CreatedAtRoute(nameof(GetRaceById), new { Id = raceReadDto.Id }, raceReadDto);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AutoMapperMappingException ex)
            {
                return BadRequest("Date or time format is incorrect.");
            }
        }

        // POST: races/deleteAll
        [HttpPost("deleteAll")]
        public ActionResult DeleteAllRaces()
        {
            _repository.DeleteAllRaces();
            _repository.SaveChanges();

            return Ok();
        }
    }
}
