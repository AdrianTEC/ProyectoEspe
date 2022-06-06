using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Data
{
    public interface IDataRepo
    {
        bool SaveChanges();

        IEnumerable<Championship> GetAllChampionships();
        Championship GetChampionshipById(string id);
        Championship GetActiveChampionship();
        void CreateChampionship(Championship championship);
        void DeleteAllChampionships();

        IEnumerable<Race> GetAllRaces();
        Race GetRaceById(int id);
        IEnumerable<Race> GetRacesByChampionshipId(string id);
        void CreateRace(Race race);
        void DeleteAllRaces();

        IEnumerable<PlayerTeam> GetPlayerTeamsByUsername(string username);
        PlayerTeam GetPlayerTeamById(int id);
        void CreatePlayerTeam(PlayerTeam playerTeam);
        void DeletePlayerTeamsByUsername(string username);

        Player GetPlayerByUsername(string username);
        void CreatePlayer(Player player);
        void AuthPlayer(string username);

        IEnumerable<Scuderia> GetAllScuderias();
        Scuderia GetScuderiaById(int id);

        IEnumerable<Driver> GetAllDrivers();
        Driver GetDriverById(int id);

        IEnumerable<Ranking> GetCurrentPublicLeagueRanking();

        PlayerNotification CreatePrivateLeagueJoinRequest(PrivateLeague privateLeague, string playerUsername);
        IEnumerable<PlayerNotification> GetNotificationsByUsername(string playerUsername);
        void AcceptPlayerInvite(int notificationId);
        void DeclineNotification(int notificationId);

        PrivateLeague GetPrivateLeagueByName(string name);
        PrivateLeague GetPrivateLeagueByInvitationCode(string invitationCode);
        void CreatePrivateLeague(PrivateLeague privateLeague);

        Login ValidatePlayerCredentials(Login login);

    }
}
