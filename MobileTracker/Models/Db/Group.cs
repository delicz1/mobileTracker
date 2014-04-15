using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MobileTracker.Controllers;
using MobileTracker.Models.Db;

namespace MobileTracker.Models
{
    public class Group
    {
        [Key]
        [Required]
        public int GroupId { get; set; }

        [Required]
        [Display(Name = "Název skupiny")]
        public string Name { get; set; }

        [Display(Name = "Popis")]
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Device> Devices { get; set; } 
    }
}