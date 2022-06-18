using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;
using System.Diagnostics;

namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerTeamsController : ControllerBase
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public PlayerTeamsController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: teams/
        [HttpGet("{playerUsername}", Name = "GetPlayerTeamsByUsername")]
        public ActionResult<IEnumerable<PlayerTeamReadDto>> GetPlayerTeamsByUsername(string playerUsername)
        {
            var playerTeams = _repository.GetPlayerTeamsByUsername(playerUsername);
            return Ok(_mapper.Map<IEnumerable<PlayerTeamReadDto>>(playerTeams));
        }

        // POST: teams/
        [HttpPost]
        public ActionResult<PlayerTeamReadDto> CreatePlayerTeam(PlayerTeamCreateDto playerTeamCreateDto)
        {
            var playerTeamModel = _mapper.Map<PlayerTeam>(playerTeamCreateDto);
            _repository.CreatePlayerTeam(playerTeamModel);
            _repository.SaveChanges();

            var playerTeamReadDto = _mapper.Map<PlayerTeamReadDto>(playerTeamModel);

            return CreatedAtRoute(nameof(GetPlayerTeamsByUsername), new { PlayerUsername = playerTeamModel.Player }, playerTeamReadDto);
        }

        // PUT: teams/
        [HttpPut]
        public ActionResult<PlayerTeamCreateDto> ModifyPlayerTeam(PlayerTeamCreateDto playerTeamCreateDto)
        {
            var playerTeamModel = _mapper.Map<PlayerTeam>(playerTeamCreateDto);
            _repository.ModifyPlayerTeam(playerTeamModel);

            var playerTeamReadDto = _mapper.Map<PlayerTeamReadDto>(playerTeamModel);

            return CreatedAtRoute(nameof(GetPlayerTeamsByUsername), new { PlayerUsername = playerTeamModel.Player }, playerTeamReadDto);
        }

        [HttpDelete("{username}")]
        public ActionResult DeletePlayerTeamsByUsername(string username)
        {
            _repository.DeletePlayerTeamsByUsername(username);
            _repository.SaveChanges();

            return Ok();
        }

    }
}
