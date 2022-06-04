using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class PrivateLeagueCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LeagueCreatorUsername { get; set; }
    }
}
