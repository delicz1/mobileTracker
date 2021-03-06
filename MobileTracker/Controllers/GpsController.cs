﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (! gpsQuery.Any())
            {
                return RedirectToAction("Details", "Device", new { id = deviceId });
            }
            ViewData["minLat"] = gpsQuery.Min(g => g.Lat).ToString("##.000000", new CultureInfo("en-US", false).NumberFormat);
            ViewData["minLng"] = gpsQuery.Min(g => g.Lng).ToString("##.000000", new CultureInfo("en-US", false).NumberFormat);
            ViewData["maxLat"] = gpsQuery.Max(g => g.Lat).ToString("##.000000", new CultureInfo("en-US", false).NumberFormat);
            ViewData["maxLng"] = gpsQuery.Max(g => g.Lng).ToString("##.000000", new CultureInfo("en-US", false).NumberFormat);
            return View(gpsQuery.ToList());
        }
    }
}
