using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileTracker.Models;

namespace MobileTracker.Controllers
{
    public class EventTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.EventTypes.ToList());
        }

        // GET: /EventType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventType eventtype = db.EventTypes.Find(id);
            if (eventtype == null)
            {
                return HttpNotFound();
            }
            return View(eventtype);
        }
        [Authorize(Roles = "Admin")]
        // GET: /EventType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EventType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include="EventTypeId,Name,Icon")] EventType eventtype)
        {
            if (ModelState.IsValid)
            {
                db.EventTypes.Add(eventtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventtype);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventType eventtype = db.EventTypes.Find(id);
            if (eventtype == null)
            {
                return HttpNotFound();
            }
            return View(eventtype);
        }

        // POST: /EventType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include="EventTypeId,Name,Icon")] EventType eventtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventtype);
        }

        // GET: /EventType/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventType eventtype = db.EventTypes.Find(id);
            if (eventtype == null)
            {
                return HttpNotFound();
            }
            return View(eventtype);
        }

        // POST: /EventType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            EventType eventtype = db.EventTypes.Find(id);
            db.EventTypes.Remove(eventtype);
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
    }
}
