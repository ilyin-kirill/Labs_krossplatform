using Microsoft.EntityFrameworkCore;
using TKR2.Models;

namespace TKR2.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Taxi> Taxis { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public Context(DbContextOptions<Context> options)
    : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
