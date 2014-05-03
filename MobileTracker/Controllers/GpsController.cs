using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MobileTracker.Models;
using MobileTracker.Models.Manager;

namespace MobileTracker.Controllers
{
    public class GpsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = IdentityManager.RoleUser)]
        public ActionResult MapActualPosition(int deviceId)
        {
//            var timestamp = DateManager.ToUnixTimestamp(DateTime.UtcNow) - 5 * DateManager.DAY_SECOND;
            var gpsQuery = from g in db.Gpses select g;
            gpsQuery = gpsQuery.Where(g => g.DeviceId.Equals(deviceId));
            gpsQuery = gpsQuery.OrderByDescending(g => g.Time);
            return View(gpsQuery.First());
        }

        [Authorize(Roles = IdentityManager.RoleUser)]
        public ActionResult MapDateInterval(int deviceId, int timeFrom, int timeTo)
        {
            var gpsQuery = from g in db.Gpses select g;
            gpsQuery = gpsQuery.Where(g => g.DeviceId.Equals(deviceId) && g.Time > timeFrom && g.Time < timeTo);
            gpsQuery = gpsQuery.OrderBy(g => g.Time);
            ViewData["test"] = gpsQuery.ToList().Count;
            return View(gpsQuery.ToList());
        }
    }
}
