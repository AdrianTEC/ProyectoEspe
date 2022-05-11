﻿using RestAPI_XF1Online.Models;

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

            championship.Id = CreateRandomChampionshipKey();
            _context.Championships.Add(championship);
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
    }
}
