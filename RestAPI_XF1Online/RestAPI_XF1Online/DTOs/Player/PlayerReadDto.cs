namespace RestAPI_XF1Online.DTOs
{
    public class PlayerReadDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string AgeRange { get; set; }
        public int Money { get; set; }
        public bool ConfirmedAccount { get; set; }
        public string? PrivateLeague { get; set; }

    }
}
