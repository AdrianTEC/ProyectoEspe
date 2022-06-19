using Microsoft.EntityFrameworkCore;
using RestAPI_XF1Online.Models;
using System.Diagnostics;

namespace RestAPI_XF1Online.Data
{
    public class SqlRepo : IDataRepo
    {
        private readonly XF1OnlineContext _context;

        public SqlRepo(XF1OnlineContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateChampionship(Championship championship)
        {
            if(championship == null)
            {
                throw new ArgumentNullException(nameof(championship));
            }

            DeactivateChampionships();
            championship.Id = CreateRandomChampionshipKey();
            championship.IsActive = true;
            _context.Championships.Add(championship);
            CreateRankings(championship);
        }

        private void CreateRankings(Championship championship)
        {
            List<PlayerTeam> playerTeams = (List<PlayerTeam>) GetAllPlayerTeams();

            foreach(PlayerTeam playerTeam in playerTeams)
            {
                Ranking ranking = new Ranking();
                ranking.Championship = championship;
                ranking.PlayerTeam = playerTeam;
                ranking.PrivateLeague = playerTeam.PrivateLeague;
                ranking.Score = 0;
                _context.Rankings.Add(ranking);
            }
        }

        private void DeactivateChampionships()
        {
            var championship = _context.Championships.FirstOrDefault(c => c.IsActive == true);
            if(championship == null)
                return;
            championship.IsActive = false;
            SaveChanges();
        }

        private string CreateRandomChampionshipKey()
        {
            var randomKey = RandomString(6);
            var championships = _context.Championships.Where(c => c.Id == randomKey & c.FinishingDate > DateTime.Today.AddYears(-3));
            if (!championships.Any())
            {
                return randomKey;
            }
            return CreateRandomChampionshipKey();
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public IEnumerable<Championship> GetAllChampionships()
        {
            return _context.Championships.ToList();
        }

        public Championship GetChampionshipById(string id)
        {
            return _context.Championships.FirstOrDefault(c => c.Id == id);
        }

        public Championship GetActiveChampionship()
        {
            return _context.Championships.FirstOrDefault(c => c.IsActive == true);
        }

        public IEnumerable<Race> GetAllRaces()
        {
            return _context.Races.ToList();
        }
        public Race GetRaceById(int id)
        {
            return _context.Races.FirstOrDefault(c => c.Id == id);
        }


        public IEnumerable<Race> GetRacesByChampionshipId(string id)
        {
            return _context.Races.Where(c => c.ChampionshipId == id);
        }

        public void CreateRace(Race race)
        {
            if (race == null)
            {
                throw new InvalidDataException("Race is null");
            }
            if (GetChampionshipById(race.ChampionshipId) == null)
            {
                throw new InvalidDataException("Championship does not exist");
            }

            race.ActualState = "Pendiente";
            _context.Races.Add(race);
        }

        public void DeleteAllChampionships()
        {
            _context.Championships.RemoveRange(_context.Championships);
        }

        public void DeleteAllRaces()
        {
            _context.Races.RemoveRange(_context.Races);
        }

        public void CreateRaceResult(IEnumerable<RaceResult> results)
        {
            _context.RaceResults.AddRange(results);

            // ModifyPrices(result);
            // ModifyTeamScores(result);
        }

        public IEnumerable<PlayerTeam> GetPlayerTeamsByUsername(string username)
        {
            var teams = _context.PlayerTeams.Where(pt => pt.Player.Username == username).Include("Drivers").Include("Scuderia").ToList();
            return teams;
        }

        private IEnumerable<PlayerTeam> GetAllPlayerTeams()
        {
            return _context.PlayerTeams.Include("PrivateLeague").ToList();
        }

        public PlayerTeam GetPlayerTeamById(int id)
        {
            return _context.PlayerTeams.Where(pt => pt.Id == id).Include("Player").Include("Scuderia")
                .Include("Drivers").Include("PrivateLeague").FirstOrDefault();
        }

        public void CreatePlayerTeam(PlayerTeam playerTeam)
        {
            playerTeam.Player = GetPlayerByUsername(playerTeam.Player.Username);
            playerTeam.Scuderia = GetScuderiaByXFIACode(playerTeam.Scuderia.XFIA_Code);
            playerTeam.Player.Money -= playerTeam.Scuderia.Price;
            playerTeam.PrivateLeague = playerTeam.Player.PrivateLeague;
            var drivers = playerTeam.Drivers;
            playerTeam.Drivers = new List<Driver>();
            foreach(Driver driver in drivers)
            {
                var driver1 = GetDriverByXFIACode(driver.XFIA_Code);
                playerTeam.Drivers.Add(driver1);
                playerTeam.Player.Money -= driver1.Price;
            }
            _context.PlayerTeams.Add(playerTeam);
            _context.Players.Update(playerTeam.Player);

            Ranking ranking = new Ranking();
            ranking.Championship = GetActiveChampionship();
            ranking.PlayerTeam = playerTeam;
            ranking.Score = 0;
            ranking.PrivateLeague = playerTeam.Player.PrivateLeague;
            _context.Rankings.Add(ranking);

        }

        public void ModifyPlayerTeam(PlayerTeam newPlayerTeam)
        {
            var playerTeam = GetPlayerTeamById(newPlayerTeam.Id);
            
            foreach (Driver driver in playerTeam.Drivers)
            {
                playerTeam.Player.Money += driver.Price;
            }
            playerTeam.Player.Money += playerTeam.Scuderia.Price;

            var newDrivers = new List<Driver>();
            foreach (Driver driver in newPlayerTeam.Drivers)
            {
                var driverModel = GetDriverByXFIACode(driver.XFIA_Code);
                playerTeam.Player.Money -= driverModel.Price;
                newDrivers.Add(driverModel);
            }
            playerTeam.Drivers = newDrivers;

            var scuderiaModel = GetScuderiaByXFIACode(newPlayerTeam.Scuderia.XFIA_Code);
            playerTeam.Player.Money -= scuderiaModel.Price;
            playerTeam.Scuderia = scuderiaModel;

            _context.PlayerTeams.Update(playerTeam);
            _context.SaveChanges();
        }

        public void DeletePlayerTeamsByUsername(string username)
        {
            _context.PlayerTeams.RemoveRange(_context.PlayerTeams.Where(pt => pt.Player.Username == username));
            var player = GetPlayerByUsername(username);
            player.Money = 100;
            _context.Players.Update(player);
        }

        public Player GetPlayerByUsername(string username)
        {
            return _context.Players.Where(p => p.Username == username).Include("PrivateLeague").FirstOrDefault();
        }

        public void CreatePlayer(Player player)
        {
            var existingPlayer = _context.Players.FirstOrDefault(p => p.Email == player.Email && p.ConfirmedAccount == true);
            if (existingPlayer != null)
            {
                throw new InvalidDataException("An account already exists with the specified email.");
            }
            player.Money = 100;
            player.ConfirmedAccount = false;
            _context.Players.Add(player);
        }
        public void AuthPlayer(string username)
        {
            var player = _context.Players.FirstOrDefault(p => p.Username == username);
            player.ConfirmedAccount = true;
            _context.Players.Update(player);
        }

        public Scuderia GetScuderiaByXFIACode(string code)
        {
            return _context.Scuderias.FirstOrDefault(pt => pt.XFIA_Code == code);
        }

        public IEnumerable<Scuderia> GetAllScuderias()
        {
            return _context.Scuderias.ToList();
        }

        public Driver GetDriverByXFIACode(string code)
        {
            return _context.Drivers.FirstOrDefault(pt => pt.XFIA_Code == code);
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return _context.Drivers.ToList();
        }

        public IEnumerable<Ranking> GetCurrentPublicLeagueRanking()
        {
            var currentChampionship = GetActiveChampionship();
            var ranking = _context.Rankings.Where(r => r.Championship.Id == currentChampionship.Id).Include("PlayerTeam")
                .Include("PlayerTeam.Player").ToList();
            return ranking;
        }

        public PlayerNotification CreatePrivateLeagueJoinRequest(PrivateLeague privateLeague, string playerUsername)
        {
            var validateNotification = _context.PlayerNotifications.Where(n => n.NotifiedPlayer.Username == playerUsername && n.Type == 2);
            if (validateNotification.Any())
                throw new InvalidDataException("Can't send two join request");
            
            var player = GetPlayerByUsername(playerUsername);
            if (player.PrivateLeague != null)
                throw new InvalidDataException("Can't join another private league");


            var notification = new PlayerNotification();
            notification.Type = 2;
            notification.NotifiedPlayer = player;
            notification.Description = "La solicitud de ingreso a la liga '" + privateLeague.Name +"' ha sido enviada";
            notification.PrivateLeague = privateLeague;
            _context.PlayerNotifications.Add(notification);

            CreatePlayerOwnerNotification(privateLeague, playerUsername);

            return notification;
        }

        private void CreatePlayerOwnerNotification(PrivateLeague privateLeague, string invitedPlayer)
        {
            var invitedPlayerModel = GetPlayerByUsername(invitedPlayer);

            var notification = new PlayerNotification();
            notification.Type = 1;
            notification.NotifiedPlayer = GetPlayerByUsername(privateLeague.LeagueCreatorUsername);
            notification.Description = "El jugador " + invitedPlayerModel.Name + " " + invitedPlayerModel.LastName  + 
                                        " (" + invitedPlayerModel.Username + ") quiere unirse a tu liga privada '" +
                                        privateLeague.Name + "'";
            notification.PrivateLeague = privateLeague;
            notification.InvitedPlayer = invitedPlayerModel;
            _context.PlayerNotifications.Add(notification);
        }

        public IEnumerable<PlayerNotification> GetNotificationsByUsername(string playerUsername)
        {
            return _context.PlayerNotifications.Where(n => n.NotifiedPlayer.Username == playerUsername).Include("NotifiedPlayer").ToList();
        }

        private PlayerNotification GetNotificationById(int notificationId)
        {
            return _context.PlayerNotifications.Where(n => n.Id == notificationId)
                .Include("InvitedPlayer")
                .Include("PrivateLeague")
                .Include("NotifiedPlayer")
                .FirstOrDefault();
        }

        public void AcceptPlayerInvite(int notificationId)
        {
            var notification = GetNotificationById(notificationId);
            AddPlayerToPrivateLeague(notification.PrivateLeague.Name, notification.InvitedPlayer.Username);
            _context.PlayerNotifications.Remove(notification);
            CreateInfoNotification(notification.InvitedPlayer.Username, notification.PrivateLeague.Name, true);

            var requestNotification = _context.PlayerNotifications
                                       .Where(n => n.Type == 2 && n.NotifiedPlayer == notification.InvitedPlayer).FirstOrDefault();
            DeleteNotification(requestNotification.Id);
        }

        private void CreateInfoNotification(string playerUsername, string leagueName, bool isAccepted)
        {
            var player = GetPlayerByUsername(playerUsername);
            var notification = new PlayerNotification();
            notification.Type = 3;
            notification.NotifiedPlayer = player;
            var action = (isAccepted) ? "aceptada" : "rechazada";
            notification.Description = "Tu solicitud de ingreso a la liga '" + leagueName + "' ha sido " + action;
            _context.PlayerNotifications.Add(notification);
        }

        private void DeleteNotification(int notificationId)
        {
            var notification = GetNotificationById(notificationId);
            _context.PlayerNotifications.Remove(notification);
        }

        public void DeclineNotification(int notificationId)
        {
            var notification = GetNotificationById(notificationId);
            switch (notification.Type)
            {
                case 1:
                    RejectRequestToLeague(notification);
                    break;
                case 2:
                    DeleteRequestNotification(notification);
                    break;
                case 3:
                    DeleteNotification(notificationId);
                    break;
            }
        }

        private void RejectRequestToLeague(PlayerNotification notification)
        {
            var joinRequestNotification = _context.PlayerNotifications.Where(n => n.NotifiedPlayer.Username == notification.InvitedPlayer.Username 
                                                                 && n.Type == 2).FirstOrDefault();
            DeleteNotification(joinRequestNotification.Id);

            CreateInfoNotification(notification.InvitedPlayer.Username, notification.PrivateLeague.Name, false);
            DeleteNotification(notification.Id);
        }

        private void DeleteRequestNotification(PlayerNotification notification)
        {
            var ownerNotification = _context.PlayerNotifications.Where(n => n.Type == 1 && n.InvitedPlayer == notification.NotifiedPlayer)
                .FirstOrDefault();
            DeleteNotification(ownerNotification.Id);
            DeleteNotification(notification.Id);
        }

        public PrivateLeague GetPrivateLeagueByName(string name)
        {
            var privateLeague = _context.PrivateLeagues.Where(pl => pl.Name == name)
                .Include("Rankings").Include("Rankings.PlayerTeam").Include("Rankings.PlayerTeam.Player").FirstOrDefault();
            return privateLeague;
        }

        public PrivateLeague GetPrivateLeagueByInvitationCode(string invitationCode)
        {
            return _context.PrivateLeagues.Where(pl => pl.InvitationCode == invitationCode).Include("Rankings").FirstOrDefault();
        }

        public void CreatePrivateLeague(PrivateLeague privateLeague)
        {
            privateLeague.Rankings = _context.Rankings
                                    .Where(r => r.PlayerTeam.Player.Username == privateLeague.LeagueCreatorUsername).ToList();
            privateLeague.InvitationCode = RandomString(6);
            privateLeague.AmountOfParticipants = 1;
            _context.PrivateLeagues.Add(privateLeague);

            UpdatePrivateLeagueColumn(privateLeague, privateLeague.LeagueCreatorUsername);
        }

        private void AddPlayerToPrivateLeague(string privateLeagueName, string playerUsername)
        {
            var privateLeague = GetPrivateLeagueByName(privateLeagueName);
            var playerRankings = _context.Rankings.Where(r => r.PlayerTeam.Player.Username == playerUsername).ToList();
            privateLeague.Rankings.AddRange(playerRankings);
            privateLeague.AmountOfParticipants += 1;
            _context.PrivateLeagues.Update(privateLeague);

            UpdatePrivateLeagueColumn(privateLeague, playerUsername);
        }

        private void UpdatePrivateLeagueColumn(PrivateLeague privateLeague, string playerUsername)
        {
            var player = _context.Players.Where(p => p.Username == playerUsername).FirstOrDefault();
            player.PrivateLeague = privateLeague;
            _context.Players.Update(player);

            var teams = GetPlayerTeamsByUsername(player.Username);
            foreach (var team in teams)
            {
                team.PrivateLeague = privateLeague;
                _context.Update(team);
            }
        }

        public Login ValidatePlayerCredentials(Login login)
        {
            var player = _context.Players.FirstOrDefault(p => p.Username == login.Username && 
                                                         p.Password == login.Password);

            login.IsPlayer = (player == null) ? false : true;
            if (login.IsPlayer)
                login.IsConfirmed = player.ConfirmedAccount;
            return login;
        }
    }
}
