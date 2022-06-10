using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.Models
{
    public class Scuderia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
