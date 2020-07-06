using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MJ_13.Data;
using MJ_13.Models;

namespace MJ_13.Controllers
{
    public class PredicadorController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Predicador
        public ActionResult Index()
        {
            var predicadores = db.Predicadores.Include(p => p.Tipo);
            return View(predicadores.ToList());
        }

        // GET: Predicador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predicadores predicadores = db.Predicadores.Find(id);
            if (predicadores == null)
            {
                return HttpNotFound();
            }
            return View(predicadores);
        }

        // GET: Predicador/Create
        public ActionResult Create()
        {
            ViewBag.TipoID = new SelectList(db.TipoPs, "ID", "Tipo");
            return View();
        }

        // POST: Predicador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Telefono,Email,TipoID,Origen")] Predicadores predicadores)
        {
            if (ModelState.IsValid)
            {
                db.Predicadores.Add(predicadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoID = new SelectList(db.TipoPs, "ID", "Tipo", predicadores.TipoID);
            return View(predicadores);
        }

        // GET: Predicador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predicadores predicadores = db.Predicadores.Find(id);
            if (predicadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoID = new SelectList(db.TipoPs, "ID", "Tipo", predicadores.TipoID);
            return View(predicadores);
        }

        // POST: Predicador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Telefono,Email,TipoID,Origen")] Predicadores predicadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predicadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoID = new SelectList(db.TipoPs, "ID", "Tipo", predicadores.TipoID);
            return View(predicadores);
        }

        // GET: Predicador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predicadores predicadores = db.Predicadores.Find(id);
            if (predicadores == null)
            {
                return HttpNotFound();
            }
            return View(predicadores);
        }

        // POST: Predicador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predicadores predicadores = db.Predicadores.Find(id);
            db.Predicadores.Remove(predicadores);
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
