using RestAPI_XF1Online.Models;
using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class PlayerTeamCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Player { get; set; }
        [Required]
        public string Scuderia { get; set; }
        [Required]
        public ICollection<string> Drivers { get; set; }
    }
}
