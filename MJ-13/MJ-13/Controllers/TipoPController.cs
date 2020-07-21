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
    public class TipoPController : Controller
    {
        private Contexto db = new Contexto();

        // GET: TipoP
        public ActionResult Index()
        {
            return View(db.TipoPs.ToList());
        }

        // GET: TipoP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoP tipoP = db.TipoPs.Find(id);
            if (tipoP == null)
            {
                return HttpNotFound();
            }
            return View(tipoP);
        }

        // GET: TipoP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo")] TipoP tipoP)
        {
            if (ModelState.IsValid)
            {
                db.TipoPs.Add(tipoP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoP);
        }

        // GET: TipoP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoP tipoP = db.TipoPs.Find(id);
            if (tipoP == null)
            {
                return HttpNotFound();
            }
            return View(tipoP);
        }

        // POST: TipoP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo")] TipoP tipoP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoP);
        }

        // GET: TipoP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoP tipoP = db.TipoPs.Find(id);
            if (tipoP == null)
            {
                return HttpNotFound();
            }
            return View(tipoP);
        }

        // POST: TipoP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoP tipoP = db.TipoPs.Find(id);
            db.TipoPs.Remove(tipoP);
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
