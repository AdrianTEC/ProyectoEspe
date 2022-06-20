namespace RestAPI_XF1Online.DTOs
{
    public class RaceResultReadDto
    {
        public int Id { get; set; }
        public int Carrera { get; set; }
        public string CodigoXFIA { get; set; }
        public string Constructor { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public float Precio { get; set; }
        public int PosicionCalificacion { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string SinCalificarCalificacion { get; set; }
        public string DescalificadoCalificacion { get; set; }
        public int PosicionCarrera { get; set; }
        public string VueltaMasRapida { get; set; }
        public string GanoACompaneroEquipo { get; set; }
        public string SinCalificarCarrera { get; set; }
        public string DescalificadoCarrera { get; set; }
    }
}
