using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MobileTracker.Models.Db
{
    public class Device
    {
        public int DeviceId { get; set; }
        [Required]
        [Display(Name = "Zařízení")]
        public string Name { get; set; }

        [Required]
        [Remote("IsImeiAvailable", "Device", AdditionalFields="DeviceId", ErrorMessage = "Zařízení s tímto Imei již v systému existuje.")]
        public string Imei { get; set; }

        [Display(Name = "Telefonní číslo")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Id skupiny")]
        public int GroupId { get; set; }

        [Display(Name = "Skupina")]
        public virtual Group Group { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Gps> Gpses { get; set; }
        public virtual ICollection<Message> Messages { get; set; } 
    }
}