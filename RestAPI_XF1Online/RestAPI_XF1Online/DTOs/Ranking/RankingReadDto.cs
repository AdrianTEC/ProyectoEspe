using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class RankingReadDto
    {
        public string PlayerUsername { get; set; }
        public string TeamName { get; set; }
        public int Score { get; set; }
    }
}
