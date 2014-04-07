using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileTracker.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Imei { get; set; }

        public string PhoneNumber { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Gps> Gpses { get; set; }
        public virtual ICollection<Message> Messages { get; set; } 
    }
}