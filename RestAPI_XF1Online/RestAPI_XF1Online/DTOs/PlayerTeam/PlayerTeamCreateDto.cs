using RestAPI_XF1Online.Models;
using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class PlayerTeamCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Player { get; set; }
        [Required]
        public int Scuderia { get; set; }
        [Required]
        public ICollection<int> Drivers { get; set; }
    }
}
