using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileTracker.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Remote("IsImeiAvailable", "Device", ErrorMessage = "Zařízení s tímto Imei již v systému existuje.")]
        public string Imei { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Gps> Gpses { get; set; }
        public virtual ICollection<Message> Messages { get; set; } 
    }
}