using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.Models
{
    public class PlayerNotification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public Player NotifiedPlayer { get; set; }
        [Required]
        public string Description { get; set; }
        public PrivateLeague? PrivateLeague { get; set; }
        public Player? InvitedPlayer { get; set; }
    }
}
