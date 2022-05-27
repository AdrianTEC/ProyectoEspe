using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.Models
{
    public class Ranking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Championship Championship { get; set; }
        [Required]
        public PlayerTeam PlayerTeam { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
