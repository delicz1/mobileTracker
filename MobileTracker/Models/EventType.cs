using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileTracker.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }
        public string Name { get; set; }

        public string Icon { get; set; }

        public virtual ICollection<Event> Events { get; set; } 
    }
}