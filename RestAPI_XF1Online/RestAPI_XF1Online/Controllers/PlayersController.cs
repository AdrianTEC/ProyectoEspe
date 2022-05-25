using RestAPI_XF1Online.Email;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;
using HtmlAgilityPack;

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

        // GET: players/{username}
        [HttpGet("auth/{username}")]
        public ActionResult AccountAuthentification(string username)
        {
            _repository.AuthPlayer(username);
            _repository.SaveChanges();

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(@"Email/accountVerified.html");

            return base.Content(htmlDocument.DocumentNode.OuterHtml, "text/html");
        }

        // POST: players/
        [HttpPost]
        public ActionResult<PlayerReadDto> CreatePlayer(PlayerCreateDto playerCreateDto)
        {
            try
            {
                var playerModel = _mapper.Map<Player>(playerCreateDto);
                _repository.CreatePlayer(playerModel);
                _repository.SaveChanges();

                EmailService.SendConfirmationEmail(playerModel);

                var playerReadDto = _mapper.Map<PlayerReadDto>(playerModel);

                return CreatedAtRoute(nameof(GetPlayerByUsername), new { Username = playerReadDto.Username }, playerReadDto);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
