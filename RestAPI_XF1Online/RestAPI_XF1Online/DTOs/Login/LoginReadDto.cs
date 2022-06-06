using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class LoginReadDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsPlayer { get; set; }
    }
}
