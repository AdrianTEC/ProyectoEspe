using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class TeamReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlayerUsername { get; set; }
        public int Score { get; set; }
    }
}
