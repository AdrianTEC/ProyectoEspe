using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class PrivateLeagueReadDto
    {
        public string Name { get; set; }
        public string LeagueCreatorUsername { get; set; }
        public List<RankingReadDto> Rankings { get; set; }
        public string InvitationCode { get; set; }
        public int AmountOfParticipants { get; set; }
    }
}
