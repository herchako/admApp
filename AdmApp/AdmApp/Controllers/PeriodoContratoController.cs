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
    [Authorize]
    public class PeriodoContratoController : Controller
    {
        private InmobiliariaContext db = new InmobiliariaContext();

        // GET: PeriodoContrato
        public ActionResult Index()
        {
            return View(db.PeriodoContratos.ToList());
        }

        // GET: PeriodoContrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodoContrato periodoContrato = db.PeriodoContratos.Find(id);
            if (periodoContrato == null)
            {
                return HttpNotFound();
            }
            return View(periodoContrato);
        }

        // GET: PeriodoContrato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeriodoContrato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Referencia,Monto,FechaComienzo,FechaFin")] PeriodoContrato periodoContrato)
        {
            if (ModelState.IsValid)
            {
                db.PeriodoContratos.Add(periodoContrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodoContrato);
        }

        // GET: PeriodoContrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodoContrato periodoContrato = db.PeriodoContratos.Find(id);
            if (periodoContrato == null)
            {
                return HttpNotFound();
            }
            return View(periodoContrato);
        }

        // POST: PeriodoContrato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Referencia,Monto,FechaComienzo,FechaFin")] PeriodoContrato periodoContrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodoContrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodoContrato);
        }

        // GET: PeriodoContrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodoContrato periodoContrato = db.PeriodoContratos.Find(id);
            if (periodoContrato == null)
            {
                return HttpNotFound();
            }
            return View(periodoContrato);
        }

        // POST: PeriodoContrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeriodoContrato periodoContrato = db.PeriodoContratos.Find(id);
            db.PeriodoContratos.Remove(periodoContrato);
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
