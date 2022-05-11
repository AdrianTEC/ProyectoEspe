using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;


namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public ChampionshipsController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: championships/active
        [HttpGet("active")]
        public ActionResult<ChampionshipReadDto> GetActiveChampionship()
        {
            var championship = _repository.GetActiveChampionship();
            return Ok(_mapper.Map<ChampionshipReadDto>(championship));
        }

        // GET: championships/{id}
        [HttpGet("{id}", Name ="GetChampionshipById")]
        public ActionResult<ChampionshipReadDto> GetChampionshipById(string id)
        {
            var championship = _repository.GetChampionshipById(id);
            return Ok(_mapper.Map<ChampionshipReadDto>(championship));
        }

        // GET: championships/
        [HttpGet]
        public ActionResult<IEnumerable<ChampionshipReadDto>> GetChampionships()
        {
            var championships = _repository.GetAllChampionships();
            return Ok(_mapper.Map<IEnumerable<ChampionshipReadDto>>(championships));
        }

        // POST: championships
        [HttpPost]
        public ActionResult<ChampionshipReadDto> CreateChampionship(ChampionshipCreateDto championshipCreateDto)
        {
            try
            {
                var championshipModel = _mapper.Map<Championship>(championshipCreateDto);
                _repository.CreateChampionship(championshipModel);
                _repository.SaveChanges();

                var championshipReadDto = _mapper.Map<ChampionshipReadDto>(championshipModel);

                return CreatedAtRoute(nameof(GetChampionshipById), new { Id = championshipReadDto.Id }, championshipReadDto);
            }catch (AutoMapperMappingException ex)
            {
                return BadRequest("Date or time format is incorrect.");
            }
        }

        // POST: championships/deleteAll
        [HttpPost("deleteAll")]
        public ActionResult DeleteAllChampionships()
        {
            _repository.DeleteAllChampionships();
            _repository.SaveChanges();

            return Ok();
        }


    }
}
