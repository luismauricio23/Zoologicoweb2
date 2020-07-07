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
    public class ZoologicosController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Zoologicos
        [AuthorizeUser(idOperacion: 80)]
        public ActionResult Index()
        {
            return View(db.Zoologicos.ToList());
        }

        // GET: Zoologicos/Details/5
        [AuthorizeUser(idOperacion: 79)]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoologicos zoologicos = db.Zoologicos.Find(id);
            if (zoologicos == null)
            {
                return HttpNotFound();
            }
            return View(zoologicos);
        }

        // GET: Zoologicos/Create
        [AuthorizeUser(idOperacion: 76)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zoologicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nit_Zoologico,Nombre_Zoologico,Direccion_Zoologico,Telefono_Zoologico,Ciudad_zoologico,Departamento_zoologico")] Zoologicos zoologicos)
        {
            if (ModelState.IsValid)
            {
                db.Zoologicos.Add(zoologicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zoologicos);
        }

        // GET: Zoologicos/Edit/5
        [AuthorizeUser(idOperacion: 77)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoologicos zoologicos = db.Zoologicos.Find(id);
            if (zoologicos == null)
            {
                return HttpNotFound();
            }
            return View(zoologicos);
        }

        // POST: Zoologicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nit_Zoologico,Nombre_Zoologico,Direccion_Zoologico,Telefono_Zoologico,Ciudad_zoologico,Departamento_zoologico")] Zoologicos zoologicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zoologicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zoologicos);
        }

        // GET: Zoologicos/Delete/
        [AuthorizeUser(idOperacion: 78)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoologicos zoologicos = db.Zoologicos.Find(id);
            if (zoologicos == null)
            {
                return HttpNotFound();
            }
            return View(zoologicos);
        }

        // POST: Zoologicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Zoologicos zoologicos = db.Zoologicos.Find(id);
            db.Zoologicos.Remove(zoologicos);
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
