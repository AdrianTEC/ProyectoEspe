using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;
using System.ComponentModel;
using System.Diagnostics;

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

        // POST: /raceResults/
        [HttpPost]
        public ActionResult<RaceResultReadArray> CreateRaceResults(RaceResultCreateArray raceResultCreateArray)
        {

            var raceResultCreateDto = raceResultCreateArray.Data;

            var raceResultsModel = _mapper.Map<IEnumerable<RaceResult>>(raceResultCreateDto);
            _repository.CreateRaceResult(raceResultsModel);
            _repository.SaveChanges();

            var raceResultReadDto = _mapper.Map<IEnumerable<RaceResultReadDto>>(raceResultsModel);
            var array = new RaceResultReadArray();
            array.Data = new List<RaceResultReadDto>(raceResultReadDto);


            return Ok(array);
        }
    }
}
