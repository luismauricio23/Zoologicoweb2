﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zoologico.Models;

namespace Zoologico.Controllers
{
    public class ParqueaderoesController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Parqueaderoes
        public ActionResult Index()
        {
            var parqueadero = db.Parqueadero.Include(p => p.Zoologicos);
            return View(parqueadero.ToList());
        }

        // GET: Parqueaderoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Create
        public ActionResult Create()
        {
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico");
            return View();
        }

        // POST: Parqueaderoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Parqueadero,Nombre_Parqueadero,Nit_Zoologico")] Parqueadero parqueadero)
        {
            if (ModelState.IsValid)
            {
                db.Parqueadero.Add(parqueadero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // POST: Parqueaderoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Parqueadero,Nombre_Parqueadero,Nit_Zoologico")] Parqueadero parqueadero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parqueadero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            return View(parqueadero);
        }

        // POST: Parqueaderoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            db.Parqueadero.Remove(parqueadero);
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
