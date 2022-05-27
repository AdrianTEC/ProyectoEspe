using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_XF1Online.Models 
{ 
    public class Championship
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name {get; set;}
        [Required]
        public DateTime StartingDate {get; set;}
        [Required]
        public DateTime FinishingDate { get; set;}
        [Required]
        public DateTime StartingTime {get; set;}
        [Required]
        public DateTime FinishingTime { get; set;}
        [MaxLength(1000)]
        public string? Description {get; set;}

        public bool IsActive {get; set;}

        public List<Race> Races {get; set;}

    }
}

