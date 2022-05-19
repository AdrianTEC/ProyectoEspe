using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;


namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public TeamsController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: teams/
        [HttpGet]
        public ActionResult<IEnumerable<TeamReadDto>> GetTeams()
        {
            var playerTeams = _repository.GetAllPlayerTeams();
            return Ok(_mapper.Map<IEnumerable<TeamReadDto>>(playerTeams));
        }
    }
}
