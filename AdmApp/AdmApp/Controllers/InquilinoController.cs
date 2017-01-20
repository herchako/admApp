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
    public class InquilinoController : Controller
    {
        private InmobiliariaContext db = new InmobiliariaContext();

        // GET: Inquilino
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Fecha" ? "date_desc" : "Fecha";

            var inquilinos = from l in db.Inquilinos
                             select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                inquilinos = inquilinos.Where(l => l.Apellido.Contains(searchString)
                                       || l.Nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    inquilinos = inquilinos.OrderByDescending(l => l.Apellido);
                    break;
                case "Fecha":
                    inquilinos = inquilinos.OrderBy(l => l.FechaDeAlta);
                    break;
                case "date_desc":
                    inquilinos = inquilinos.OrderByDescending(l => l.FechaDeAlta);
                    break;
                default:
                    inquilinos = inquilinos.OrderBy(s => s.Apellido);
                    break;
            }

            return View(inquilinos.ToList());
        }

        // GET: Inquilino/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquilino inquilino = db.Inquilinos.Find(id);
            if (inquilino == null)
            {
                return HttpNotFound();
            }
            return View(inquilino);
        }

        // GET: Inquilino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilino/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,Email,Telefono,Celular,Direccion,Observaciones,FechaDeAlta")] Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                db.Inquilinos.Add(inquilino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inquilino);
        }

        // GET: Inquilino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquilino inquilino = db.Inquilinos.Find(id);
            if (inquilino == null)
            {
                return HttpNotFound();
            }
            return View(inquilino);
        }

        // POST: Inquilino/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Apellido,Email,Telefono,Celular,Direccion,Observaciones,FechaDeAlta")] Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inquilino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inquilino);
        }

        // GET: Inquilino/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquilino inquilino = db.Inquilinos.Find(id);
            if (inquilino == null)
            {
                return HttpNotFound();
            }
            return View(inquilino);
        }

        // POST: Inquilino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inquilino inquilino = db.Inquilinos.Find(id);
            db.Inquilinos.Remove(inquilino);
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
