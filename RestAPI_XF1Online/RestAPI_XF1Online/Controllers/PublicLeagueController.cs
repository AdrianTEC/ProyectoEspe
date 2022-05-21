using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;


namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicLeagueController : ControllerBase
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public PublicLeagueController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: publicLeague/
        [HttpGet]
        public ActionResult<IEnumerable<RankingReadDto>> GetPublicLeagueRanking()
        {
            var rankings = _repository.GetCurrentPublicLeagueRanking();
            return Ok(_mapper.Map<IEnumerable<RankingReadDto>>(rankings));
        }
    }

}
