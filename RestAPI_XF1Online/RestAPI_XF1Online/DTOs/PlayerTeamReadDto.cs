using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.DTOs
{
    public class PlayerTeamReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeamReadDto Team { get; set; }
        public List<DriverReadDto> Drivers { get; set; }
    }
}
