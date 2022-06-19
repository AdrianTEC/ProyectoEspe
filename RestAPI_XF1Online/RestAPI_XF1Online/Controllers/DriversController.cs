using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;


namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public DriversController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: drivers/
        [HttpGet]
        public ActionResult<IEnumerable<DriverReadDto>> GetDrivers()
        {
            var drivers = _repository.GetAllDrivers();
            return Ok(_mapper.Map<IEnumerable<DriverReadDto>>(drivers));
        }
    }

}
