using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Opticar.Data;
using Opticar.Models.Optics;

namespace Opticar.Controllers
{
    public class DiametersController : Controller
    {
        private OpticsDbContext db = new OpticsDbContext();

        // GET: Diameters
        public ActionResult Index()
        {
            return View(db.Diameters.ToList());
        }

        // GET: Diameters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var diameter = db.Diameters.Find(id);
            if (diameter == null)
            {
                return HttpNotFound();
            }
            return View(diameter);
        }

        // GET: Diameters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiameterId,Value")] Diameter diameter)
        {
            if (ModelState.IsValid)
            {
                db.Diameters.Add(diameter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diameter);
        }

        // GET: Diameters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var diameter = db.Diameters.Find(id);
            if (diameter == null)
            {
                return HttpNotFound();
            }
            return View(diameter);
        }

        // POST: Diameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiameterId,Value")] Diameter diameter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diameter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diameter);
        }

        // GET: Diameters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var diameter = db.Diameters.Find(id);
            if (diameter == null)
            {
                return HttpNotFound();
            }
            return View(diameter);
        }

        // POST: Diameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var diameter = db.Diameters.Find(id);
            db.Diameters.Remove(diameter);
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
