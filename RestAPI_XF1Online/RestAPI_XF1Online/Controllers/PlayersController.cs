using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public PlayersController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: players/{username}
        [HttpGet("{username}", Name = "GetPlayerByUsername")]
        public ActionResult<PlayerReadDto> GetPlayerByUsername(string username)
        {
            var player = _repository.GetPlayerByUsername(username);
            return Ok(_mapper.Map<PlayerReadDto>(player));
        }

        // POST: players/
        [HttpPost]
        public ActionResult<PlayerReadDto> CreateRace(PlayerCreateDto playerCreateDto)
        {
            var playerModel = _mapper.Map<Player>(playerCreateDto);
            _repository.CreatePlayer(playerModel);
            _repository.SaveChanges();

            var playerReadDto = _mapper.Map<PlayerReadDto>(playerModel);

            return CreatedAtRoute(nameof(GetPlayerByUsername), new { Username = playerReadDto.Username }, playerReadDto);
        }
    }
}
