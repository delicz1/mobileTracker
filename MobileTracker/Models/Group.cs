using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MobileTracker.Controllers;

namespace MobileTracker.Models
{
    public class Group
    {
        [Key]
        [Required]
        public int GroupId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Device> Devices { get; set; } 
    }
}