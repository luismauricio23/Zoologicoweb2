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
    public class CitasController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Citas
        [AuthorizeUser(idOperacion: 15)]
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.Animales).Include(c => c.Veterinario);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        [AuthorizeUser(idOperacion: 14)]
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
        [AuthorizeUser(idOperacion: 11)]
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
        [AuthorizeUser(idOperacion: 12)]
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
        [AuthorizeUser(idOperacion: 13)]
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
        // GET: Citas
        [AuthorizeUser(idOperacion: 90)]
        public ActionResult Index2()
        {
            var citas = db.Citas.Include(c => c.Animales).Include(c => c.Veterinario);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        [AuthorizeUser(idOperacion: 89)]
        public ActionResult Details2(string id)
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
        [AuthorizeUser(idOperacion: 86)]
        public ActionResult Create2()
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
        public ActionResult Create2([Bind(Include = "Codigo_Cita,Hora_inicio_Cita,Hora_fin_Cita,Diagnostico_Cita,Observaciones,Cedula_Veterinario,Id_Animal")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(citas);
                db.SaveChanges();
                return RedirectToAction("Index2");
            }

            ViewBag.Id_Animal = new SelectList(db.Animales, "Id_Animal", "Nombre_Animal", citas.Id_Animal);
            ViewBag.Cedula_Veterinario = new SelectList(db.Veterinario, "Cedula_Veterinario", "Nombre_Veterinario", citas.Cedula_Veterinario);
            return View(citas);
        }

        // GET: Citas/Edit/5
        [AuthorizeUser(idOperacion: 87)]
        public ActionResult Edit2(string id)
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
        public ActionResult Edit2([Bind(Include = "Codigo_Cita,Hora_inicio_Cita,Hora_fin_Cita,Diagnostico_Cita,Observaciones,Cedula_Veterinario,Id_Animal")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            ViewBag.Id_Animal = new SelectList(db.Animales, "Id_Animal", "Nombre_Animal", citas.Id_Animal);
            ViewBag.Cedula_Veterinario = new SelectList(db.Veterinario, "Cedula_Veterinario", "Nombre_Veterinario", citas.Cedula_Veterinario);
            return View(citas);
        }

        // GET: Citas/Delete/5
        [AuthorizeUser(idOperacion: 88)]
        public ActionResult Delete2(string id)
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
        [HttpPost, ActionName("Delete2")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete2Confirmed(string id)
        {
            Citas citas = db.Citas.Find(id);
            db.Citas.Remove(citas);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}
