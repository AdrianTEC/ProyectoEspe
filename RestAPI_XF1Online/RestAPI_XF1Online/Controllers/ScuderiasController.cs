using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;


namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScuderiasController : ControllerBase
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public ScuderiasController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: Scuderias/
        [HttpGet]
        public ActionResult<IEnumerable<ScuderiaReadDto>> GetScuderias()
        {
            var scuderias = _repository.GetAllScuderias();
            return Ok(_mapper.Map<IEnumerable<ScuderiaReadDto>>(scuderias));
        }
    }

}
