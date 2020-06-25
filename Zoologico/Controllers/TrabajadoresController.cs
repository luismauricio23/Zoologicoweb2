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
    public class TrabajadoresController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Trabajadores
        [AuthorizeUser(idOperacion:5)]
        public ActionResult Index()
        {
            var trabajadores = db.Trabajadores.Include(t => t.Rol).Include(t => t.Zonas);
            return View(trabajadores.ToList());
        }

        // GET: Trabajadores/Details/5
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // GET: Trabajadores/Create
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Create()
        {
            ViewBag.idRol_Trabajador = new SelectList(db.Rol, "id", "nombre");
            ViewBag.Id_Zona = new SelectList(db.Zonas, "Id_Zona", "Nombre_Zona");
            return View();
        }

        // POST: Trabajadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Trabajador,Cedula_Trabajador,Nombre_Trabajador,Apellido_Trabajador,Telefono_Trabajador,Direccion_Trabajador,Id_Zona,idRol_Trabajador,password_Trabajador,Correo_Trabajador,Edad_Trabajador")] Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Trabajadores.Add(trabajadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRol_Trabajador = new SelectList(db.Rol, "id", "nombre", trabajadores.idRol_Trabajador);
            ViewBag.Id_Zona = new SelectList(db.Zonas, "Id_Zona", "Nombre_Zona", trabajadores.Id_Zona);
            return View(trabajadores);
        }

        // GET: Trabajadores/Edit/5
        [AuthorizeUser(idOperacion: 2)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRol_Trabajador = new SelectList(db.Rol, "id", "nombre", trabajadores.idRol_Trabajador);
            ViewBag.Id_Zona = new SelectList(db.Zonas, "Id_Zona", "Nombre_Zona", trabajadores.Id_Zona);
            return View(trabajadores);
        }

        // POST: Trabajadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Trabajador,Cedula_Trabajador,Nombre_Trabajador,Apellido_Trabajador,Telefono_Trabajador,Direccion_Trabajador,Id_Zona,idRol_Trabajador,password_Trabajador,Correo_Trabajador,Edad_Trabajador")] Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRol_Trabajador = new SelectList(db.Rol, "id", "nombre", trabajadores.idRol_Trabajador);
            ViewBag.Id_Zona = new SelectList(db.Zonas, "Id_Zona", "Nombre_Zona", trabajadores.Id_Zona);
            return View(trabajadores);
        }

        // GET: Trabajadores/Delete/5
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajadores trabajadores = db.Trabajadores.Find(id);
            db.Trabajadores.Remove(trabajadores);
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
