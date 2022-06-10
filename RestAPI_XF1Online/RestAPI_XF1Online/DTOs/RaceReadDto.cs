namespace RestAPI_XF1Online.DTOs
{
    public class RaceReadDto
    {
        public int Id { get; set; }
        public string ChampionshipId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string TrackName { get; set; }

        public string ActualState { get; set; }

        public string StartingDate { get; set; }

        public string FinishingDate { get; set; }

        public string StartingTime { get; set; }

        public string FinishingTime { get; set; }
    }
}
