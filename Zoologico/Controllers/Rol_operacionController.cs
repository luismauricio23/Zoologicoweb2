using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zoologico.Filters;
using Zoologico.Models;

namespace Zoologico.Controllers
{
    public class Rol_operacionController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Rol_operacion
        [AuthorizeUser(idOperacion: 50)]
        public ActionResult Index()
        {
            var rol_operacion = db.Rol_operacion.Include(r => r.Operacion).Include(r => r.Rol);
            return View(rol_operacion.ToList());
        }

        // GET: Rol_operacion/Details/5
        [AuthorizeUser(idOperacion: 49)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_operacion rol_operacion = db.Rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // GET: Rol_operacion/Create
        [AuthorizeUser(idOperacion: 46)]
        public ActionResult Create()
        {
            ViewBag.idOperacion = new SelectList(db.Operacion, "id", "nombre");
            ViewBag.idRol = new SelectList(db.Rol, "id", "nombre");
            return View();
        }

        // POST: Rol_operacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idRol,idOperacion")] Rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.Rol_operacion.Add(rol_operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOperacion = new SelectList(db.Operacion, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.Rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // GET: Rol_operacion/Edit/5
        [AuthorizeUser(idOperacion: 47)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_operacion rol_operacion = db.Rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOperacion = new SelectList(db.Operacion, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.Rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // POST: Rol_operacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idRol,idOperacion")] Rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOperacion = new SelectList(db.Operacion, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.Rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // GET: Rol_operacion/Delete/5
        [AuthorizeUser(idOperacion: 48)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_operacion rol_operacion = db.Rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // POST: Rol_operacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol_operacion rol_operacion = db.Rol_operacion.Find(id);
            db.Rol_operacion.Remove(rol_operacion);
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
