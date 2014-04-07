using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileTracker.Models
{
    public class Gps
    {
        public int GpsId { get; set; }

        public int DeviceId { get; set; }
        public int Time { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }

        public virtual Device Device { get; set; }
    }
}