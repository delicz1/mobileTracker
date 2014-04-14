using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MobileTracker.Models;
using MobileTracker.Models.Db;

namespace MobileTracker.Controllers
{
    public class DeviceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Device/
        public ActionResult Index()
        {
            var devices = db.Devices.Include(d => d.Group);
            return View(devices.ToList());
        }

        // GET: /Device/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: /Device/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name");
            return View();
        }

        // POST: /Device/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DeviceId,Name,Imei,PhoneNumber,GroupId")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Devices.Add(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", device.GroupId);
            return View(device);
        }

        // GET: /Device/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", device.GroupId);
            return View(device);
        }

        // POST: /Device/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DeviceId,Name,Imei,PhoneNumber,GroupId")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Entry(device).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", device.GroupId);
            return View(device);
        }

        // GET: /Device/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: /Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Device device = db.Devices.Find(id);
            db.Devices.Remove(device);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public ActionResult IndexUserView()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var group = user.Group;
            var devices = group.Devices;
            return View(devices.ToList());
        }

        public JsonResult IsImeiAvailable(string imei)
        {
            return Json(!db.Devices.Any(i => i.Imei == imei), JsonRequestBehavior.AllowGet);
        }
    }
}
