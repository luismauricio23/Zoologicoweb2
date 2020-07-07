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
    public class TiquetesController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Tiquetes
        [AuthorizeUser(idOperacion: 60)]
        public ActionResult Index()
        {
            var tiquete = db.Tiquete.Include(t => t.Parqueadero).Include(t => t.Vehiculo);
            return View(tiquete.ToList());
        }

        // GET: Tiquetes/Details/5
        [AuthorizeUser(idOperacion: 59)]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiquete tiquete = db.Tiquete.Find(id);
            if (tiquete == null)
            {
                return HttpNotFound();
            }
            return View(tiquete);
        }

        // GET: Tiquetes/Create
        [AuthorizeUser(idOperacion: 56)]
        public ActionResult Create()
        {
            ViewBag.Id_Parqueadero = new SelectList(db.Parqueadero, "Id_Parqueadero", "Nombre_Parqueadero");
            ViewBag.Placa_Vehiculo = new SelectList(db.Vehiculo, "Placa_Vehiculo", "Tipo_Vehiculo");
            return View();
        }

        // POST: Tiquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero_Tiquete,Hora_Ingreso_Tiquete,Hora_salida_Tiquete,Valor_Hora_Tiquete,Id_Parqueadero,Placa_Vehiculo")] Tiquete tiquete)
        {
            if (ModelState.IsValid)
            {
                db.Tiquete.Add(tiquete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Parqueadero = new SelectList(db.Parqueadero, "Id_Parqueadero", "Nombre_Parqueadero", tiquete.Id_Parqueadero);
            ViewBag.Placa_Vehiculo = new SelectList(db.Vehiculo, "Placa_Vehiculo", "Tipo_Vehiculo", tiquete.Placa_Vehiculo);
            return View(tiquete);
        }

        // GET: Tiquetes/Edit/5
        [AuthorizeUser(idOperacion: 57)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiquete tiquete = db.Tiquete.Find(id);
            if (tiquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Parqueadero = new SelectList(db.Parqueadero, "Id_Parqueadero", "Nombre_Parqueadero", tiquete.Id_Parqueadero);
            ViewBag.Placa_Vehiculo = new SelectList(db.Vehiculo, "Placa_Vehiculo", "Tipo_Vehiculo", tiquete.Placa_Vehiculo);
            return View(tiquete);
        }

        // POST: Tiquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero_Tiquete,Hora_Ingreso_Tiquete,Hora_salida_Tiquete,Valor_Hora_Tiquete,Id_Parqueadero,Placa_Vehiculo")] Tiquete tiquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiquete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Parqueadero = new SelectList(db.Parqueadero, "Id_Parqueadero", "Nombre_Parqueadero", tiquete.Id_Parqueadero);
            ViewBag.Placa_Vehiculo = new SelectList(db.Vehiculo, "Placa_Vehiculo", "Tipo_Vehiculo", tiquete.Placa_Vehiculo);
            return View(tiquete);
        }

        // GET: Tiquetes/Delete/5
        [AuthorizeUser(idOperacion: 58)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiquete tiquete = db.Tiquete.Find(id);
            if (tiquete == null)
            {
                return HttpNotFound();
            }
            return View(tiquete);
        }

        // POST: Tiquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tiquete tiquete = db.Tiquete.Find(id);
            db.Tiquete.Remove(tiquete);
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
