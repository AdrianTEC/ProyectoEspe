using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class LoginReadDto
    {
        public string Username { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
