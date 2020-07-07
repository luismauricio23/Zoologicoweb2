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
    public class ParqueaderoesController : Controller
    {
        private ZoologicoWebEntities1 db = new ZoologicoWebEntities1();

        // GET: Parqueaderoes
        [AuthorizeUser(idOperacion: 40)]
        public ActionResult Index()
        {
            var parqueadero = db.Parqueadero.Include(p => p.Zoologicos);
            return View(parqueadero.ToList());
        }

        // GET: Parqueaderoes/Details/5
        [AuthorizeUser(idOperacion: 39)]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Create
        [AuthorizeUser(idOperacion: 36)]
        public ActionResult Create()
        {
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico");
            return View();
        }

        // POST: Parqueaderoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Parqueadero,Nombre_Parqueadero,Nit_Zoologico")] Parqueadero parqueadero)
        {
            if (ModelState.IsValid)
            {
                db.Parqueadero.Add(parqueadero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Edit/5
        [AuthorizeUser(idOperacion: 37)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // POST: Parqueaderoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Parqueadero,Nombre_Parqueadero,Nit_Zoologico")] Parqueadero parqueadero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parqueadero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Delete/5
        [AuthorizeUser(idOperacion: 38)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            return View(parqueadero);
        }

        // POST: Parqueaderoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            db.Parqueadero.Remove(parqueadero);
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

        // GET: Parqueaderoes
        [AuthorizeUser(idOperacion: 105)]
        public ActionResult Index2()
        {
            var parqueadero = db.Parqueadero.Include(p => p.Zoologicos);
            return View(parqueadero.ToList());
        }

        // GET: Parqueaderoes/Details/5
        [AuthorizeUser(idOperacion: 104)]
        public ActionResult Details2(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Create
        [AuthorizeUser(idOperacion: 101)]
        public ActionResult Create2()
        {
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico");
            return View();
        }

        // POST: Parqueaderoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "Id_Parqueadero,Nombre_Parqueadero,Nit_Zoologico")] Parqueadero parqueadero)
        {
            if (ModelState.IsValid)
            {
                db.Parqueadero.Add(parqueadero);
                db.SaveChanges();
                return RedirectToAction("Index2");
            }

            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Edit/5
        [AuthorizeUser(idOperacion: 102)]
        public ActionResult Edit2(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // POST: Parqueaderoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "Id_Parqueadero,Nombre_Parqueadero,Nit_Zoologico")] Parqueadero parqueadero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parqueadero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            ViewBag.Nit_Zoologico = new SelectList(db.Zoologicos, "Nit_Zoologico", "Nombre_Zoologico", parqueadero.Nit_Zoologico);
            return View(parqueadero);
        }

        // GET: Parqueaderoes/Delete/5
        [AuthorizeUser(idOperacion: 103)]
        public ActionResult Delete2(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            if (parqueadero == null)
            {
                return HttpNotFound();
            }
            return View(parqueadero);
        }

        // POST: Parqueaderoes/Delete/5
        [HttpPost, ActionName("Delete2")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete2Confirmed(string id)
        {
            Parqueadero parqueadero = db.Parqueadero.Find(id);
            db.Parqueadero.Remove(parqueadero);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}
