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
    public class ContratoController : Controller
    {
        private InmobiliariaContext db = new InmobiliariaContext();

        // GET: Contrato
        public ActionResult Index()
        {
            var inquilinos = db.Inquilinos.ToList();
            ViewBag.inquilinos = inquilinos;
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            var contratos = db.Contratos.Include(c => c.Propiedad);
            return View(contratos.ToList());
        }

        // GET: Contrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            var inquilinos = db.Inquilinos.ToList();
            ViewBag.inquilinos = inquilinos;
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View(contrato);
        }

        // GET: Contrato/Create
        public ActionResult Create()
        {
            ViewBag.PropiedadID = new SelectList(db.Propiedades, "ID", "Direccion");
            var inquilinos = db.Inquilinos.ToList();
            ViewBag.inquilinos = inquilinos;
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View();
        }

        // POST: Contrato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LocadorID,InquilinoID,PropiedadID,Referencia,GarantiaNombre,GarantiaTelefono,Vencimiento,Observaciones")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contratos.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropiedadID = new SelectList(db.Propiedades, "ID", "Calle", contrato.PropiedadID);
            return View(contrato);
        }

        // GET: Contrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropiedadID = new SelectList(db.Propiedades, "ID", "Direccion", contrato.PropiedadID);
            var inquilinos = db.Inquilinos.ToList();
            ViewBag.inquilinos = inquilinos;
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View(contrato);
        }

        // POST: Contrato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LocadorID,InquilinoID,PropiedadID,Referencia,GarantiaNombre,GarantiaTelefono,Vencimiento,Observaciones")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropiedadID = new SelectList(db.Propiedades, "ID", "Direccion", contrato.PropiedadID);
            return View(contrato);
        }

        // GET: Contrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            var inquilinos = db.Inquilinos.ToList();
            ViewBag.inquilinos = inquilinos;
            var locadores = db.Locadores.ToList();
            ViewBag.locadores = locadores;
            return View(contrato);
        }

        // POST: Contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contratos.Find(id);
            db.Contratos.Remove(contrato);
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
