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
    public class LensesController : Controller
    {
        private OpticsDbContext db = new OpticsDbContext();

        // GET: Lenses
        public ActionResult Index()
        {
            var lenses = db.Lenses.Include(l => l.DeliveryTime).Include(l => l.Layer).Include(l => l.LenseDesign).Include(l => l.LenseType);
            return View(lenses.ToList());
        }

        // GET: Lenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lense = db.Lenses.Find(id);
            if (lense == null)
            {
                return HttpNotFound();
            }
            return View(lense);
        }

        // GET: Lenses/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryTimeId = new SelectList(db.DeliveryTimes, "DeliveryTimeId", "Description");
            ViewBag.LayerId = new SelectList(db.Layers, "LayerId", "Name");
            ViewBag.LenseDesignId = new SelectList(db.LenseDesigns, "LenseDesignId", "DisplayName");
            ViewBag.LenseTypeId = new SelectList(db.LenseTypes, "LenseTypeId", "DisplayName");
            return View();
        }

        // POST: Lenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LenseId,ManufacturerLenseId,InternalLenseId,FullName,Lager,LocalLager,Special,Transition,Sunglass,Polarisation,BrandId,LayerId,LenseTypeId,DeliveryTimeId,LenseDesignId")] Lense lense)
        {
            if (ModelState.IsValid)
            {
                db.Lenses.Add(lense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryTimeId = new SelectList(db.DeliveryTimes, "DeliveryTimeId", "Description", lense.DeliveryTimeId);
            ViewBag.LayerId = new SelectList(db.Layers, "LayerId", "Name", lense.LayerId);
            ViewBag.LenseDesignId = new SelectList(db.LenseDesigns, "LenseDesignId", "DisplayName", lense.LenseDesignId);
            ViewBag.LenseTypeId = new SelectList(db.LenseTypes, "LenseTypeId", "DisplayName", lense.LenseTypeId);
            return View(lense);
        }

        // GET: Lenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lense = db.Lenses.Find(id);
            if (lense == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryTimeId = new SelectList(db.DeliveryTimes, "DeliveryTimeId", "Description", lense.DeliveryTimeId);
            ViewBag.LayerId = new SelectList(db.Layers, "LayerId", "Name", lense.LayerId);
            ViewBag.LenseDesignId = new SelectList(db.LenseDesigns, "LenseDesignId", "DisplayName", lense.LenseDesignId);
            ViewBag.LenseTypeId = new SelectList(db.LenseTypes, "LenseTypeId", "DisplayName", lense.LenseTypeId);
            return View(lense);
        }

        // POST: Lenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LenseId,ManufacturerLenseId,InternalLenseId,FullName,Lager,LocalLager,Special,Transition,Sunglass,Polarisation,BrandId,LayerId,LenseTypeId,DeliveryTimeId,LenseDesignId")] Lense lense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryTimeId = new SelectList(db.DeliveryTimes, "DeliveryTimeId", "Description", lense.DeliveryTimeId);
            ViewBag.LayerId = new SelectList(db.Layers, "LayerId", "Name", lense.LayerId);
            ViewBag.LenseDesignId = new SelectList(db.LenseDesigns, "LenseDesignId", "DisplayName", lense.LenseDesignId);
            ViewBag.LenseTypeId = new SelectList(db.LenseTypes, "LenseTypeId", "DisplayName", lense.LenseTypeId);
            return View(lense);
        }

        // GET: Lenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lense = db.Lenses.Find(id);
            if (lense == null)
            {
                return HttpNotFound();
            }
            return View(lense);
        }

        // POST: Lenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lense lense = db.Lenses.Find(id);
            db.Lenses.Remove(lense);
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
