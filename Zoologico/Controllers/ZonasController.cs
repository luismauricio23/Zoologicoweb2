using System;
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
    public class ZonasController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Zonas
        public ActionResult Index()
        {
            var zonas = db.Zonas.Include(z => z.Zoologicos);
            return View(zonas.ToList());
        }

        // GET: Zonas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zonas zonas = db.Zonas.Find(id);
            if (zonas == null)
            {
                return HttpNotFound();
            }
            return View(zonas);
        }

        // GET: Zonas/Create
        public ActionResult Create()
        {
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico");
            return View();
        }

        // POST: Zonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Zona,Nombre_Zona,Nit_Zoologico")] Zonas zonas)
        {
            if (ModelState.IsValid)
            {
                db.Zonas.Add(zonas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", zonas.Nit_Zoologico);
            return View(zonas);
        }

        // GET: Zonas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zonas zonas = db.Zonas.Find(id);
            if (zonas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", zonas.Nit_Zoologico);
            return View(zonas);
        }

        // POST: Zonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Zona,Nombre_Zona,Nit_Zoologico")] Zonas zonas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zonas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", zonas.Nit_Zoologico);
            return View(zonas);
        }

        // GET: Zonas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zonas zonas = db.Zonas.Find(id);
            if (zonas == null)
            {
                return HttpNotFound();
            }
            return View(zonas);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Zonas zonas = db.Zonas.Find(id);
            db.Zonas.Remove(zonas);
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
