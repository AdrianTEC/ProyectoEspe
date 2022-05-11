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
        public DbSet<Race> Races { get; set; }
    }
}
