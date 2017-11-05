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
    public class LenseDesignsController : Controller
    {
        private OpticsDbContext db = new OpticsDbContext();

        // GET: LenseDesigns
        public ActionResult Index()
        {
            return View(db.LenseDesigns.ToList());
        }

        // GET: LenseDesigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LenseDesign lenseDesign = db.LenseDesigns.Find(id);
            if (lenseDesign == null)
            {
                return HttpNotFound();
            }
            return View(lenseDesign);
        }

        // GET: LenseDesigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LenseDesigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LenseDesignId,DisplayName")] LenseDesign lenseDesign)
        {
            if (ModelState.IsValid)
            {
                db.LenseDesigns.Add(lenseDesign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lenseDesign);
        }

        // GET: LenseDesigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LenseDesign lenseDesign = db.LenseDesigns.Find(id);
            if (lenseDesign == null)
            {
                return HttpNotFound();
            }
            return View(lenseDesign);
        }

        // POST: LenseDesigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LenseDesignId,DisplayName")] LenseDesign lenseDesign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lenseDesign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lenseDesign);
        }

        // GET: LenseDesigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LenseDesign lenseDesign = db.LenseDesigns.Find(id);
            if (lenseDesign == null)
            {
                return HttpNotFound();
            }
            return View(lenseDesign);
        }

        // POST: LenseDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LenseDesign lenseDesign = db.LenseDesigns.Find(id);
            db.LenseDesigns.Remove(lenseDesign);
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
