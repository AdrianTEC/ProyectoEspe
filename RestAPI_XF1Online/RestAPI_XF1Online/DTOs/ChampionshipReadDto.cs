using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs 
{ 
    public class ChampionshipReadDto
    {
        public string Id { get; set; }
        public string Name {get; set;}
        public string StartingDate {get; set;}
        public string FinishingDate { get; set;}
        public string StartingTime {get; set;}
        public string FinishingTime { get; set;}
        public string? Description {get; set;}

    }
}

