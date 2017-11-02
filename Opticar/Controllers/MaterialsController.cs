﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Opticar.Data;
using Opticar.Models.Base;
using Opticar.Models.Optics;
using Opticar.Models.ViewModels;

namespace Opticar.Controllers
{
    public class MaterialsController : Controller
    {
        private OpticsDbContext db = new OpticsDbContext();

        // GET: Materials
        public ActionResult Index()
        {
            var matList = db.Materials.ToList();
            var viemModel = matList.Select(mat => new MaterialViewModel
                {
                    MaterialId = mat.MaterialId,
                    Value = mat.Value,
                    SelectedText = db.MaterialTypes.Find(mat.MaterialId)?.Description
                })
                .ToList();
            return View(viemModel);
        }

        // GET: Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MaterialViewModel
            {
                Value = material.Value,
                SelectedText = db.MaterialTypes.Find(id)?.Description
            };

            return View(viewModel);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            var viewModel = new MaterialViewModel
            {
                MaterialTypes = db.MaterialTypes.Select(mt => new SelectListItem { Value = mt.MaterialTypeId.ToString(), Text = mt.Description })
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaterialViewModel material)
        {
            if (ModelState.IsValid)
            {
                db.Materials.Add(new Material
                {
                    Value = material.Value,
                    MaterialTypeId = material.MaterialTypeId
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(material);
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MaterialViewModel
            {
                MaterialId = material.MaterialId,
                Value = material.Value,
                MaterialTypes = db.MaterialTypes.Select(mt => new SelectListItem { Value = mt.MaterialTypeId.ToString(), Text = mt.Description, Selected = mt.MaterialTypeId.Equals(material.MaterialId) })
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MaterialViewModel material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new Material
                {
                    Value = material.Value,
                    MaterialTypeId = material.MaterialTypeId
                }).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(material);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MaterialViewModel
            {
                MaterialId = material.MaterialId,
                Value = material.Value,
                SelectedText = db.MaterialTypes.Find(id)?.Description
            };

            return View(viewModel);

        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var material = db.Materials.Find(id);
            db.Materials.Remove(material);
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
