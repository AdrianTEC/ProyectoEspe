using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_XF1Online.Models 
{ 
    public class Race
    {
        [Key]
        public int Id { get; set; }

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
        public string ActualState { get; set; }

        [Required]
        public DateTime StartingDate {get; set;}

        [Required]
        public DateTime FinishingDate { get; set;}

        [Required]
        public DateTime StartingTime {get; set;}

        [Required]
        public DateTime FinishingTime { get; set;}


    }
}

