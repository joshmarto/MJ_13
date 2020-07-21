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
            var predicadores = db.Predicadores.Include(p => p.Clasificacion).Include(p => p.Tipo);
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
            ViewBag.ClasificacionID = new SelectList(db.Clasificaciones, "ID", "Clasificacion");
            ViewBag.TipoID = new SelectList(db.TipoPs, "ID", "Tipo");
            return View();
        }

        // POST: Predicador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Telefono,Email,TipoID,ClasificacionID,Localidad")] Predicadores predicadores)
        {
            if (ModelState.IsValid)
            {
                db.Predicadores.Add(predicadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasificacionID = new SelectList(db.Clasificaciones, "ID", "Clasificacion", predicadores.ClasificacionID);
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
            ViewBag.ClasificacionID = new SelectList(db.Clasificaciones, "ID", "Clasificacion", predicadores.ClasificacionID);
            ViewBag.TipoID = new SelectList(db.TipoPs, "ID", "Tipo", predicadores.TipoID);
            return View(predicadores);
        }

        // POST: Predicador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Telefono,Email,TipoID,ClasificacionID,Localidad")] Predicadores predicadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predicadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasificacionID = new SelectList(db.Clasificaciones, "ID", "Clasificacion", predicadores.ClasificacionID);
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
