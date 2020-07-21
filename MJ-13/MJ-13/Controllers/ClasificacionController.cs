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
    public class ClasificacionController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Clasificacion
        public ActionResult Index()
        {
            return View(db.Clasificaciones.ToList());
        }

        // GET: Clasificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificaciones clasificaciones = db.Clasificaciones.Find(id);
            if (clasificaciones == null)
            {
                return HttpNotFound();
            }
            return View(clasificaciones);
        }

        // GET: Clasificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clasificacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Clasificacion")] Clasificaciones clasificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Clasificaciones.Add(clasificaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clasificaciones);
        }

        // GET: Clasificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificaciones clasificaciones = db.Clasificaciones.Find(id);
            if (clasificaciones == null)
            {
                return HttpNotFound();
            }
            return View(clasificaciones);
        }

        // POST: Clasificacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Clasificacion")] Clasificaciones clasificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clasificaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clasificaciones);
        }

        // GET: Clasificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificaciones clasificaciones = db.Clasificaciones.Find(id);
            if (clasificaciones == null)
            {
                return HttpNotFound();
            }
            return View(clasificaciones);
        }

        // POST: Clasificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clasificaciones clasificaciones = db.Clasificaciones.Find(id);
            db.Clasificaciones.Remove(clasificaciones);
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
