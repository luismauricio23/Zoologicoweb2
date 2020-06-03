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
    public class OperacionsController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Operacions
        public ActionResult Index()
        {
            var operacion = db.Operacion.Include(o => o.Modelo);
            return View(operacion.ToList());
        }

        // GET: Operacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacion operacion = db.Operacion.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            return View(operacion);
        }

        // GET: Operacions/Create
        public ActionResult Create()
        {
            ViewBag.idModulo = new SelectList(db.Modelo, "id", "nombre");
            return View();
        }

        // POST: Operacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,idModulo")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                db.Operacion.Add(operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idModulo = new SelectList(db.Modelo, "id", "nombre", operacion.idModulo);
            return View(operacion);
        }

        // GET: Operacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacion operacion = db.Operacion.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idModulo = new SelectList(db.Modelo, "id", "nombre", operacion.idModulo);
            return View(operacion);
        }

        // POST: Operacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,idModulo")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idModulo = new SelectList(db.Modelo, "id", "nombre", operacion.idModulo);
            return View(operacion);
        }

        // GET: Operacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacion operacion = db.Operacion.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            return View(operacion);
        }

        // POST: Operacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operacion operacion = db.Operacion.Find(id);
            db.Operacion.Remove(operacion);
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
