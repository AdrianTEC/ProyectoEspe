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
    public class PlayerNotificationsController : ControllerBase
    {
        private readonly IDataRepo _repository;
        private readonly IMapper _mapper;

        public PlayerNotificationsController(IDataRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: playerNotifications/{playerUsername}
        [HttpGet("{playerUsername}")]
        public ActionResult<IEnumerable<PlayerNotificationReadDto>> GetNotificationsByPlayerUsername(string playerUsername)
        {
            var notifications = _repository.GetNotificationsByUsername(playerUsername);
            return Ok(_mapper.Map<IEnumerable<PlayerNotificationReadDto>>(notifications));
        }

        // POST: playerNotifications/accept/{notificationId}
        [HttpPost("accept/{notificationId}")]
        public ActionResult AcceptNotification(int notificationId)
        {
            _repository.AcceptPlayerInvite(notificationId);
            _repository.SaveChanges();

            return Ok();
        }

        // DELETE: playerNotifications/decline/{notificationId}
        [HttpDelete("decline/{notificationId}")]
        public ActionResult CreatePrivateLeague(int notificationId)
        {
            _repository.DeclineNotification(notificationId);
            _repository.SaveChanges();

            return Ok();
        }

    }
}
