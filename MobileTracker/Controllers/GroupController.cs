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
    public class GroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Group/
        public ActionResult Index()
        {
            return View(db.GroupDbs.ToList());
        }

        // GET: /Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupDb groupdb = db.GroupDbs.Find(id);
            if (groupdb == null)
            {
                return HttpNotFound();
            }
            return View(groupdb);
        }

        // GET: /Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description")] GroupDb groupdb)
        {
            if (ModelState.IsValid)
            {
                db.GroupDbs.Add(groupdb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupdb);
        }

        // GET: /Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupDb groupdb = db.GroupDbs.Find(id);
            if (groupdb == null)
            {
                return HttpNotFound();
            }
            return View(groupdb);
        }

        // POST: /Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description")] GroupDb groupdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupdb);
        }

        // GET: /Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupDb groupdb = db.GroupDbs.Find(id);
            if (groupdb == null)
            {
                return HttpNotFound();
            }
            return View(groupdb);
        }

        // POST: /Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupDb groupdb = db.GroupDbs.Find(id);
            db.GroupDbs.Remove(groupdb);
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
