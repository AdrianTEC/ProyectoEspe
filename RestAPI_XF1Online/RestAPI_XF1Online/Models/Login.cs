using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.Models
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsPlayer { get; set; }
    }
}
