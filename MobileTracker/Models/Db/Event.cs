using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileTracker.Models.Db;

namespace MobileTracker.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public int DeviceId { get; set; }
        public int EventTypeId { get; set; }
        public int Time { get; set; }

        public virtual Device Device { get; set; }
        public virtual EventType EventType { get; set; }
    }
}