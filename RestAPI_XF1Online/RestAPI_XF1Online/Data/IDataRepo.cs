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

        IEnumerable<PlayerTeam> GetAllPlayerTeams();

        Player GetPlayerByUsername(string username);
        void CreatePlayer(Player player);

    }
}
