using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MobileTracker.Models.Db
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}