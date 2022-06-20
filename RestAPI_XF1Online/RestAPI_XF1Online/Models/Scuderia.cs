using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_XF1Online.Models
{
    public class Scuderia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string XFIA_Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public int? LastScore { get; set; }
    }
}
