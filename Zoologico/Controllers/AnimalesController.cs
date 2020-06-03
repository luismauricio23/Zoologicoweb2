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
    public class AnimalesController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Animales
        public ActionResult Index()
        {
            var animales = db.Animales.Include(a => a.Zonas);
            return View(animales.ToList());
        }

        // GET: Animales/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            return View(animales);
        }

        // GET: Animales/Create
        public ActionResult Create()
        {
            ViewBag.Id_Zona = new SelectList(db.Zonas, "Id_Zona", "Nombre_Zona");
            return View();
        }

        // POST: Animales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Animal,Nombre_Animal,Especie_Animal,Categoria_Animal,Id_Zona,Edad_Animal,Descripcion_Animal,Nombre_Cientifico_Animal,Tiempo_Zoologico")] Animales animales)
        {
            if (ModelState.IsValid)
            {
                db.Animales.Add(animales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Zona = new SelectList(db.Zonas, "Id_Zona", "Nombre_Zona", animales.Id_Zona);
            return View(animales);
        }

        // GET: Animales/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Zona = new SelectList(db.Zonas, "Id_Zona", "Nombre_Zona", animales.Id_Zona);
            return View(animales);
        }

        // POST: Animales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Animal,Nombre_Animal,Especie_Animal,Categoria_Animal,Id_Zona,Edad_Animal,Descripcion_Animal,Nombre_Cientifico_Animal,Tiempo_Zoologico")] Animales animales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Zona = new SelectList(db.Zonas, "Id_Zona", "Nombre_Zona", animales.Id_Zona);
            return View(animales);
        }

        // GET: Animales/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            return View(animales);
        }

        // POST: Animales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Animales animales = db.Animales.Find(id);
            db.Animales.Remove(animales);
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
