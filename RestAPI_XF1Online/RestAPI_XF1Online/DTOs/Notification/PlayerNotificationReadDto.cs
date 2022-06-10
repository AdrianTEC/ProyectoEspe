using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.DTOs
{
    public class PlayerNotificationReadDto
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string NotifiedPlayer { get; set; }
        public string Description { get; set; }
    }
}
