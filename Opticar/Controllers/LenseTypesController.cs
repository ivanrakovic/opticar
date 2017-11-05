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
    public class LenseTypesController : Controller
    {
        private OpticsDbContext db = new OpticsDbContext();

        // GET: LenseTypes
        public ActionResult Index()
        {
            return View(db.LenseTypes.ToList());
        }

        // GET: LenseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LenseType lenseType = db.LenseTypes.Find(id);
            if (lenseType == null)
            {
                return HttpNotFound();
            }
            return View(lenseType);
        }

        // GET: LenseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LenseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LenseTypeId,DisplayName")] LenseType lenseType)
        {
            if (ModelState.IsValid)
            {
                db.LenseTypes.Add(lenseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lenseType);
        }

        // GET: LenseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LenseType lenseType = db.LenseTypes.Find(id);
            if (lenseType == null)
            {
                return HttpNotFound();
            }
            return View(lenseType);
        }

        // POST: LenseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LenseTypeId,DisplayName")] LenseType lenseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lenseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lenseType);
        }

        // GET: LenseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LenseType lenseType = db.LenseTypes.Find(id);
            if (lenseType == null)
            {
                return HttpNotFound();
            }
            return View(lenseType);
        }

        // POST: LenseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LenseType lenseType = db.LenseTypes.Find(id);
            db.LenseTypes.Remove(lenseType);
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
