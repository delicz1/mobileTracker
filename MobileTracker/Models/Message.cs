using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace MobileTracker.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public int Time { get; set; }
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }
    }
}