﻿using System;
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
    public class PendienteController : Controller
    {
        private InmobiliariaContext db = new InmobiliariaContext();

        // GET: Pendiente
        public ActionResult Index()
        {
            return View(db.Pendientes.ToList());
        }

        // GET: Pendiente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pendiente pendiente = db.Pendientes.Find(id);
            if (pendiente == null)
            {
                return HttpNotFound();
            }
            return View(pendiente);
        }

        // GET: Pendiente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pendiente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Referencia,Monto,FechaEmision,FechaVencimiento,Observaciones")] Pendiente pendiente)
        {
            if (ModelState.IsValid)
            {
                db.Pendientes.Add(pendiente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pendiente);
        }

        // GET: Pendiente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pendiente pendiente = db.Pendientes.Find(id);
            if (pendiente == null)
            {
                return HttpNotFound();
            }
            return View(pendiente);
        }

        // POST: Pendiente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Referencia,Monto,FechaEmision,FechaVencimiento,Observaciones")] Pendiente pendiente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pendiente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pendiente);
        }

        // GET: Pendiente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pendiente pendiente = db.Pendientes.Find(id);
            if (pendiente == null)
            {
                return HttpNotFound();
            }
            return View(pendiente);
        }

        // POST: Pendiente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pendiente pendiente = db.Pendientes.Find(id);
            db.Pendientes.Remove(pendiente);
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
