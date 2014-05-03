using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobileTracker.Models;
using System.Threading.Tasks;
using MobileTracker.Models.Db;

namespace MobileTracker
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public void DoWork()
        {
            var db = new ApplicationDbContext();
            db.EventTypes.Add(new EventType
            {
                Name = "testovaci event type"
            });
            db.SaveChanges();
        }

        public bool UserExist(string userName, string password)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var task = um.FindAsync(userName, password);
            task.Wait();
            var user = task.Result;
            var result = (user != null) ? true : false;
            return result;
        }

        public bool CheckDevice(string userName, string password, string imei)
        {
            var db = new ApplicationDbContext();
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var task = um.FindAsync(userName, password);
            task.Wait();
            var user = task.Result;
            var devices = db.Devices.Where(i => i.Imei == imei);
            var result = (user != null && devices.Count() == 1) ? true : false;
            return result;
        }

        public int WriteGps(string userName, string password, string imei, string time, string lat, string lng)
        {
            var result = 0;
            var db = new ApplicationDbContext();
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var task = um.FindAsync(userName, password);
            task.Wait();
            var user = task.Result;
            var devices = db.Devices.Where(i => i.Imei == imei);
            var intTime = int.Parse(time);
            var doubleLat = double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture);
            var doubleLng = double.Parse(lng, System.Globalization.CultureInfo.InvariantCulture);

            if (user != null && devices.Count() == 1)
            {
                var device = devices.First();
                var gpses = db.Gpses.Where(i => i.DeviceId == device.DeviceId && i.Time == intTime);
                if (!gpses.Any())
                {
                    db.Gpses.Add(new Gps
                    {
                        DeviceId = device.DeviceId,
                        Time = intTime,
                        Lat = doubleLat,
                        Lng = doubleLng,
                    });
                    result = db.SaveChanges();
                }
            }
            return result;
        }

        public string DeviceJson(string userName, string password, string imei)
        {
            return "test data";
        }

        public test TestJson(string id)
        {
            return new test { testName = id };
        }
    }

    public class test
    {
        public string testName { get; set; }
    }
}
