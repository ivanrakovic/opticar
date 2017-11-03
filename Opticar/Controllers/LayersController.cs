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
    public class LayersController : Controller
    {
        private OpticsDbContext db = new OpticsDbContext();

        // GET: Layers
        public ActionResult Index()
        {
            var layers = db.Layers.Include(l => l.Manufacturer);
            return View(layers.ToList());
        }

        // GET: Layers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var layer = db.Layers.Find(id);
            if (layer == null)
            {
                return HttpNotFound();
            }
            return View(layer);
        }

        // GET: Layers/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            return View();
        }

        // POST: Layers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LayerId,Name,ManufacturerId")] Layer layer)
        {
            if (ModelState.IsValid)
            {
                db.Layers.Add(layer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", layer.ManufacturerId);
            return View(layer);
        }

        // GET: Layers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var layer = db.Layers.Find(id);
            if (layer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", layer.ManufacturerId);
            return View(layer);
        }

        // POST: Layers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LayerId,Name,ManufacturerId")] Layer layer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(layer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", layer.ManufacturerId);
            return View(layer);
        }

        // GET: Layers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var layer = db.Layers.Find(id);
            if (layer == null)
            {
                return HttpNotFound();
            }
            return View(layer);
        }

        // POST: Layers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var layer = db.Layers.Find(id);
            db.Layers.Remove(layer);
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
