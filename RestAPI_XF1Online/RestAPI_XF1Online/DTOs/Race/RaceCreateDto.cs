using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class RaceCreateDto
    {
        [Required]
        public string ChampionshipId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string TrackName { get; set; }

        [Required]
        public string StartingDate { get; set; }

        [Required]
        public string FinishingDate { get; set; }

        [Required]
        public string StartingTime { get; set; }

        [Required]
        public string FinishingTime { get; set; }
    }
}
