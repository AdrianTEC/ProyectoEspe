using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_XF1Online.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string AgeRange { get; set; }
        [Required]
        public int Money { get; set; }
        [Required]
        public bool ConfirmedAccount { get; set; } 
        public PrivateLeague? PrivateLeague { get; set; }
    }
}
