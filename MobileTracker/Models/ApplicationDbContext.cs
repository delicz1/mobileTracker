using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobileTracker.Models.Db;

namespace MobileTracker.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Gps> Gpses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
//        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}