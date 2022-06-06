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
    public class PrivateLeagueController : ControllerBase
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public PrivateLeagueController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: privateLeague/{name}
        [HttpGet("{name}", Name = "GetPrivateLeagueByName")]
        public ActionResult<PrivateLeagueReadDto> GetPrivateLeagueByName(string name)
        {
            var privateLeague = _repository.GetPrivateLeagueByName(name);
            return Ok(_mapper.Map<PrivateLeagueReadDto>(privateLeague));
        }

        // POST: privateLeague/joinRequest/
        [HttpPost("joinRequest", Name = "JoinRequestByInvitationCode")]
        public ActionResult<PlayerNotificationReadDto> JoinRequestByInvitationCode(JoinPrivateLeagueDto joinInfo)
        {
            try
            {
                var privateLeague = _repository.GetPrivateLeagueByInvitationCode(joinInfo.InvitationCode);
                if (privateLeague == null)
                    return BadRequest("No existe una liga privada con ese código de acceso");
                var notification = _repository.CreatePrivateLeagueJoinRequest(privateLeague, joinInfo.PlayerUsername);
                var notificationReadDto = _mapper.Map<PlayerNotificationReadDto>(notification);
                _repository.SaveChanges();

                //var privateLeagueReadDto = _mapper.Map<PrivateLeagueReadDto>(privateLeague);
                //privateLeague = _repository.AddPlayerToPrivateLeague(privateLeague, joinInfo.PlayerUsername);

                return Ok(notificationReadDto);
            }catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: privateLeague/
        [HttpPost]
        public ActionResult<PrivateLeagueReadDto> CreatePrivateLeague(PrivateLeagueCreateDto privateLeagueCreateDto)
        {
            var privateLeagueModel = _mapper.Map<PrivateLeague>(privateLeagueCreateDto);
            _repository.CreatePrivateLeague(privateLeagueModel);
            _repository.SaveChanges();

            var privateLeagueReadDto = _mapper.Map<PrivateLeagueReadDto>(privateLeagueModel);

            return CreatedAtRoute(nameof(GetPrivateLeagueByName), new { Name = privateLeagueModel.Name }, privateLeagueReadDto);
        }

    }
}
