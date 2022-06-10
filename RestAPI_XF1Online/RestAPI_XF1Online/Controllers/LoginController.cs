using RestAPI_XF1Online.Email;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI_XF1Online.Data;
using RestAPI_XF1Online.DTOs;
using RestAPI_XF1Online.Models;
using HtmlAgilityPack;
using System.Diagnostics;

namespace RestAPI_XF1Online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public LoginController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // POST: login/
        [HttpPost]
        public ActionResult<LoginReadDto> CreatePlayer(LoginCreateDto loginCreateDto)
        {
            var loginModel = _mapper.Map<Login>(loginCreateDto);
            loginModel = _repository.ValidatePlayerCredentials(loginModel);

            Debug.WriteLine("LA VALIDACION ES: " + loginModel.IsPlayer);

            var loginReadDto = _mapper.Map<LoginReadDto>(loginModel);

            return Ok(loginReadDto);
        }
    }
}
