using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using MobileTracker.Models.Db;

namespace MobileTracker.Models
{
    public class Gps
    {
        public int GpsId { get; set; }

        public int DeviceId { get; set; }
        public int Time { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public virtual Device Device { get; set; }

        public string GetLat()
        {
            return Lat.ToString("##.000000", new CultureInfo("en-US", false).NumberFormat);
        }

        public string GetLng()
        {
            return Lng.ToString("##.000000", new CultureInfo("en-US", false).NumberFormat);
        }
    }

    public class GpsMapTimeSelect
    {
        [Required]
        public int DeviceId { get; set; }

        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }

    }
}