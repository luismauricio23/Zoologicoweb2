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
    public class ModeloesController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Modeloes
        [AuthorizeUser(idOperacion: 30)]
        public ActionResult Index()
        {
            return View(db.Modelo.ToList());
        }

        // GET: Modeloes/Details/5
        [AuthorizeUser(idOperacion: 29)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // GET: Modeloes/Create
        [AuthorizeUser(idOperacion: 26)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modeloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                db.Modelo.Add(modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Modeloes/Edit/5
        [AuthorizeUser(idOperacion: 27)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modeloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Modeloes/Delete/5
        [AuthorizeUser(idOperacion: 28)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo modelo = db.Modelo.Find(id);
            db.Modelo.Remove(modelo);
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
