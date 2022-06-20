using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_XF1Online.Models
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string XFIA_Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public float Price { get; set; }
        public List<PlayerTeam> PlayerTeams { get; set; }
        public int LastScore { get; set; }
    }
}
