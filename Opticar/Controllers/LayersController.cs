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
using Opticar.Models.ViewModels;

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
            var pId = id ?? -1;
            if (pId == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var layer = db.Layers.Find(pId);
            if (layer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new LayersViewModel 
            {
                LayerId = layer.LayerId,
                Name = layer.Name,
                SelectedText = db.Manufacturers.Find(layer.ManufacturerId).Name
            };

            return View(viewModel);

        }

        // GET: Layers/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            var viewModel = new LayersViewModel
            {
                Manufacturers = db.Manufacturers.Select(mt => new SelectListItem { Value = mt.ManufacturerId.ToString(), Text = mt.Name })
            };
            return View(viewModel);
        }

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
            var pId = id ?? -1;
            if (pId == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var layer = db.Layers.Find(pId);
            if (layer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new LayersViewModel
            {
                LayerId = layer.LayerId,
                Name = layer.Name,
                SelectedText = db.Manufacturers.Find(layer.ManufacturerId).Name
            };

            return View(viewModel);

        }

        // POST: Layers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LayersViewModel layer)
        {
            if (ModelState.IsValid)
            {
                var lay = new Layer
                {
                    LayerId = layer.LayerId,
                    Name = layer.Name
                };
                db.Layers.Attach(lay);
                db.Entry(lay).Property(x => x.Name).IsModified = true;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(layer);
        }

        // GET: Layers/Delete/5
        public ActionResult Delete(int? id)
        {
            var pId = id ?? -1;
            if (pId == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var layer = db.Layers.Find(pId);
            if (layer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new LayersViewModel
            {
                LayerId = layer.LayerId,
                Name = layer.Name,
                SelectedText = db.Manufacturers.Find(layer.ManufacturerId).Name
            };

            return View(viewModel);

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
