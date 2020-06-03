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
    public class CitasController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Citas
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.Animales).Include(c => c.Veterinario);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Animal = new SelectList(db.Animales, "Id_Animal", "Nombre_Animal");
            ViewBag.Cedula_Veterinario = new SelectList(db.Veterinario, "Cedula_Veterinario", "Nombre_Veterinario");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Cita,Hora_inicio_Cita,Hora_fin_Cita,Diagnostico_Cita,Observaciones,Cedula_Veterinario,Id_Animal")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(citas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Animal = new SelectList(db.Animales, "Id_Animal", "Nombre_Animal", citas.Id_Animal);
            ViewBag.Cedula_Veterinario = new SelectList(db.Veterinario, "Cedula_Veterinario", "Nombre_Veterinario", citas.Cedula_Veterinario);
            return View(citas);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Animal = new SelectList(db.Animales, "Id_Animal", "Nombre_Animal", citas.Id_Animal);
            ViewBag.Cedula_Veterinario = new SelectList(db.Veterinario, "Cedula_Veterinario", "Nombre_Veterinario", citas.Cedula_Veterinario);
            return View(citas);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Cita,Hora_inicio_Cita,Hora_fin_Cita,Diagnostico_Cita,Observaciones,Cedula_Veterinario,Id_Animal")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Animal = new SelectList(db.Animales, "Id_Animal", "Nombre_Animal", citas.Id_Animal);
            ViewBag.Cedula_Veterinario = new SelectList(db.Veterinario, "Cedula_Veterinario", "Nombre_Veterinario", citas.Cedula_Veterinario);
            return View(citas);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Citas citas = db.Citas.Find(id);
            db.Citas.Remove(citas);
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
