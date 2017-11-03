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
    public class DeliveryTimesController : Controller
    {
        private readonly OpticsDbContext db = new OpticsDbContext();

        // GET: DeliveryTimes
        public ActionResult Index()
        {
            return View(db.DeliveryTimes.ToList());
        }

        // GET: DeliveryTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var deliveryTime = db.DeliveryTimes.Find(id);
            if (deliveryTime == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTime);
        }

        // GET: DeliveryTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryTimeId,Description")] DeliveryTime deliveryTime)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryTimes.Add(deliveryTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryTime);
        }

        // GET: DeliveryTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var deliveryTime = db.DeliveryTimes.Find(id);
            if (deliveryTime == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTime);
        }

        // POST: DeliveryTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryTimeId,Description")] DeliveryTime deliveryTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryTime);
        }

        // GET: DeliveryTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var deliveryTime = db.DeliveryTimes.Find(id);
            if (deliveryTime == null)
            {
                return HttpNotFound();
            }
            return View(deliveryTime);
        }

        // POST: DeliveryTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deliveryTime = db.DeliveryTimes.Find(id);
            db.DeliveryTimes.Remove(deliveryTime);
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
