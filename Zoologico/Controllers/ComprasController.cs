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
    public class ComprasController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Compras
        [AuthorizeUser(idOperacion: 25)]
        public ActionResult Index()
        {
            var compra = db.Compra.Include(c => c.Cliente).Include(c => c.Planes);
            return View(compra.ToList());
        }

        // GET: Compras/Details/5
        [AuthorizeUser(idOperacion: 24)]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        [AuthorizeUser(idOperacion: 21)]
        public ActionResult Create()
        {
            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente");
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan");
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero_Compra,Fecha_Compra,Cantidad_Compra,Valor_Compra,Id_Plan,Cedula_Cliente")] Compra compra)
        {
         

            if (ModelState.IsValid)
            {
                db.Compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente", compra.Cedula_Cliente);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan", compra.Id_Plan);
            return View(compra);
        }

        // GET: Compras/Edit/5
        [AuthorizeUser(idOperacion: 22)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente", compra.Cedula_Cliente);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan", compra.Id_Plan);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero_Compra,Fecha_Compra,Cantidad_Compra,Valor_Compra,Id_Plan,Cedula_Cliente")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente", compra.Cedula_Cliente);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan", compra.Id_Plan);
            return View(compra);
        }

        // GET: Compras/Delete/5
        [AuthorizeUser(idOperacion: 23)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Compra compra = db.Compra.Find(id);
            db.Compra.Remove(compra);
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
        // GET: Compras
        [AuthorizeUser(idOperacion: 100)]
        public ActionResult Index2()
        {
            var compra = db.Compra.Include(c => c.Cliente).Include(c => c.Planes);
            return View(compra.ToList());
        }

        // GET: Compras/Details/5
        [AuthorizeUser(idOperacion: 99)]
        public ActionResult Details2(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        [AuthorizeUser(idOperacion: 96)]
        public ActionResult Create2()
        {
            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente");
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan");
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "Numero_Compra,Fecha_Compra,Cantidad_Compra,Valor_Compra,Id_Plan,Cedula_Cliente")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index2");
            }

            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente", compra.Cedula_Cliente);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan", compra.Id_Plan);
            return View(compra);
        }

        // GET: Compras/Edit/5
        [AuthorizeUser(idOperacion: 97)]
        public ActionResult Edit2(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente", compra.Cedula_Cliente);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan", compra.Id_Plan);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "Numero_Compra,Fecha_Compra,Cantidad_Compra,Valor_Compra,Id_Plan,Cedula_Cliente")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente", compra.Cedula_Cliente);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan", compra.Id_Plan);
            return View(compra);
        }

        // GET: Compras/Delete/5
        [AuthorizeUser(idOperacion: 98)]
        public ActionResult Delete2(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete2")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete2Confirmed(string id)
        {
            Compra compra = db.Compra.Find(id);
            db.Compra.Remove(compra);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult Reservacion()
        {
            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente");
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan");
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservacion([Bind(Include = "Numero_Compra,Fecha_Compra,Cantidad_Compra,Valor_Compra,Id_Plan,Cedula_Cliente")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Reservacion","Home");
            }

            ViewBag.Cedula_Cliente = new SelectList(db.Cliente, "Cedula_Cliente", "Nombre_Cliente", compra.Cedula_Cliente);
            ViewBag.Id_Plan = new SelectList(db.Planes, "Id_Plan", "Nombre_Plan", compra.Id_Plan);
            return View(compra);
        }

    }
}
