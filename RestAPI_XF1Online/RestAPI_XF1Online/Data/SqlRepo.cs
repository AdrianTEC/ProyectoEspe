﻿using Microsoft.EntityFrameworkCore;
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
            CreatePublicLeague(championship);
        }

        private void CreatePublicLeague(Championship championship)
        {
            List<PlayerTeam> playerTeams = (List<PlayerTeam>) GetAllPlayerTeams();

            foreach(PlayerTeam playerTeam in playerTeams)
            {
                Ranking ranking = new Ranking();
                ranking.Championship = championship;
                ranking.PlayerTeam = playerTeam;
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

        public IEnumerable<PlayerTeam> GetPlayerTeamsByUsername(string username)
        {
            var teams = _context.PlayerTeams.Where(pt => pt.Player.Username == username).Include("Drivers").Include("Team").ToList();
            return teams;
        }

        private IEnumerable<PlayerTeam> GetAllPlayerTeams()
        {
            return _context.PlayerTeams.ToList();
        }

        public PlayerTeam GetPlayerTeamById(int id)
        {
            return _context.PlayerTeams.FirstOrDefault(pt => pt.Id == id);
        }

        public void CreatePlayerTeam(PlayerTeam playerTeam)
        {
            playerTeam.Player = GetPlayerByUsername(playerTeam.Player.Username);
            playerTeam.Team = GetTeamById(playerTeam.Team.Id);
            var drivers = playerTeam.Drivers;
            playerTeam.Drivers = new List<Driver>();
            foreach(Driver driver in drivers)
            {
                playerTeam.Drivers.Add(GetDriverById(driver.Id));
            }
            _context.PlayerTeams.Add(playerTeam);
        }

        public Player GetPlayerByUsername(string username)
        {
            return _context.Players.FirstOrDefault(p => p.Username == username);
        }

        public void CreatePlayer(Player player)
        {
            player.ConfirmedAccount = false;
            _context.Players.Add(player);
        }

        public Team GetTeamById(int id)
        {
            return _context.Teams.FirstOrDefault(pt => pt.Id == id);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        public Driver GetDriverById(int id)
        {
            return _context.Drivers.FirstOrDefault(pt => pt.Id == id);
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
    }
}
