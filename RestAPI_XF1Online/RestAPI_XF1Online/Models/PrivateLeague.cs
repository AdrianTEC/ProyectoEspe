using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.Models
{
    public class PrivateLeague
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string LeagueCreatorUsername { get; set; }
        [Required]
        public List<Ranking> Rankings { get; set; }
        [Required]
        public string InvitationCode { get; set; }
        [Required]
        public int AmountOfParticipants { get; set; }
    }
}
