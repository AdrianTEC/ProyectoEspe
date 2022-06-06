using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class LoginCreateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
