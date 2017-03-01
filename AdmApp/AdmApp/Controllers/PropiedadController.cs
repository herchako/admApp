using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdmApp.DAL;
using AdmApp.Models;

namespace AdmApp.Controllers
{
    public class PropiedadController : Controller
    {
        private InmobiliariaContext db = new InmobiliariaContext();

        // GET: Propiedad
        public ActionResult Index()
        {
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View(db.Propiedades.ToList());
        }

        // GET: Propiedad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propiedad propiedad = db.Propiedades.Find(id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View(propiedad);
        }

        // GET: Propiedad/Create
        public ActionResult Create()
        {
            var inquilinos = db.Inquilinos.ToList();
            ViewBag.inquilinos = inquilinos;
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View();
        }

        // POST: Propiedad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LocadorID,Calle,Altura,Observaciones")] Propiedad propiedad)
        {
            if (ModelState.IsValid)
            {
                db.Propiedades.Add(propiedad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propiedad);
        }

        // GET: Propiedad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propiedad propiedad = db.Propiedades.Find(id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            var inquilinos = db.Inquilinos.ToList();
            ViewBag.inquilinos = inquilinos;

            return View(propiedad);
        }

        // POST: Propiedad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LocadorID,Calle,Altura,Observaciones")] Propiedad propiedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propiedad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View(propiedad);
        }

        // GET: Propiedad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propiedad propiedad = db.Propiedades.Find(id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View(propiedad);
        }

        // POST: Propiedad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propiedad propiedad = db.Propiedades.Find(id);
            db.Propiedades.Remove(propiedad);
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
