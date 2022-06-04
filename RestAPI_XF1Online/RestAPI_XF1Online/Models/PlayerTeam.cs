using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.Models
{
    public class PlayerTeam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Player Player { get; set; }

        [Required]
        public Scuderia Scuderia { get; set; }
        [Required]
        public virtual List<Driver> Drivers { get; set; }
        public PrivateLeague? PrivateLeague { get; set; }
    }
}
