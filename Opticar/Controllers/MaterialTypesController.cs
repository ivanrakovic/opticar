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
    public class MaterialTypesController : Controller
    {
        private readonly OpticsDbContext _db = new OpticsDbContext();

        // GET: MaterialTypes
        public ActionResult Index()
        {
            return View(_db.MaterialTypes.ToList());
        }

        // GET: MaterialTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var materialType = _db.MaterialTypes.Find(id);
            if (materialType == null)
            {
                return HttpNotFound();
            }
            return View(materialType);
        }

        // GET: MaterialTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaterialTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialTypeId,Description")] MaterialType materialType)
        {
            if (ModelState.IsValid)
            {
                _db.MaterialTypes.Add(materialType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialType);
        }

        // GET: MaterialTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var materialType = _db.MaterialTypes.Find(id);
            if (materialType == null)
            {
                return HttpNotFound();
            }
            return View(materialType);
        }

        // POST: MaterialTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialTypeId,Description")] MaterialType materialType)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(materialType).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materialType);
        }

        // GET: MaterialTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var materialType = _db.MaterialTypes.Find(id);
            if (materialType == null)
            {
                return HttpNotFound();
            }
            return View(materialType);
        }

        // POST: MaterialTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var materialType = _db.MaterialTypes.Find(id);
            _db.MaterialTypes.Remove(materialType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
