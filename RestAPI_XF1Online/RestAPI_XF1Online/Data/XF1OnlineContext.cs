using Microsoft.EntityFrameworkCore;
using RestAPI_XF1Online.Models;

namespace RestAPI_XF1Online.Data
{
    public class XF1OnlineContext: DbContext
    {
        public XF1OnlineContext(DbContextOptions<XF1OnlineContext> opt) : base(opt)
        {

        }

        public DbSet<Championship> Championships { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
