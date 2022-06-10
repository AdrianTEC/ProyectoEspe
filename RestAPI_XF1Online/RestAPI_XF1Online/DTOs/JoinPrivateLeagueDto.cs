using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class JoinPrivateLeagueDto
    {
        [Required]
        public string InvitationCode { get; set; }
        [Required]
        public string PlayerUsername { get; set; }
    }
}
