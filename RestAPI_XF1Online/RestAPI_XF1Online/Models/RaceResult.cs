using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.Models
{
    public class RaceResult
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Race Carrera { get; set; }
        [Required]
        public string CodigoXFIA { get; set; }
        [Required]
        public string Constructor { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public int PosicionCalificacion { get; set; }
        [Required]
        public string Q1 { get; set; }
        [Required]
        public string Q2 { get; set; }
        [Required]
        public string Q3 { get; set; }
        [Required]
        public string SinCalificarCalificacion { get; set; }
        [Required]
        public string DescalificadoCalificacion { get; set; }
        [Required]
        public int PosicionCarrera { get; set; }
        [Required]
        public string VueltaMasRapida { get; set; }
        [Required]
        public string GanoACompaneroEquipo { get; set; }
        [Required]
        public string SinCalificarCarrera { get; set; }
        [Required]
        public string DescalificadoCarrera { get; set; }
    }
}
