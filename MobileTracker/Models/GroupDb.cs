using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MobileTracker.Models
{
    public class GroupDb
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers;
    }

    public class GroupDbContext : ApplicationDbContext
    {
        public DbSet<GroupDb> Groups { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}