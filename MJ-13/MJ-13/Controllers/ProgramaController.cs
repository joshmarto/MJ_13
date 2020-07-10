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
    public class ProgramaController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Programa
        public ActionResult Index()
        {
            var programas = db.Programas.Include(p => p.Lider);
            return View(programas.ToList());
        }

        // GET: Programa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programas programas = db.Programas.Find(id);
            if (programas == null)
            {
                return HttpNotFound();
            }
            return View(programas);
        }

        // GET: Programa/Create
        public ActionResult Create()
        {
            ViewBag.LiderID = new SelectList(db.LideresVs, "ID", "Nombre");
            return View();
        }

        // POST: Programa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Programa,LiderID,Descripcion,Observaciones")] Programas programas)
        {
            if (ModelState.IsValid)
            {
                db.Programas.Add(programas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LiderID = new SelectList(db.LideresVs, "ID", "Nombre", programas.LiderID);
            return View(programas);
        }

        // GET: Programa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programas programas = db.Programas.Find(id);
            if (programas == null)
            {
                return HttpNotFound();
            }
            ViewBag.LiderID = new SelectList(db.LideresVs, "ID", "Nombre", programas.LiderID);
            return View(programas);
        }

        // POST: Programa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Programa,LiderID,Descripcion,Observaciones")] Programas programas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LiderID = new SelectList(db.LideresVs, "ID", "Nombre", programas.LiderID);
            return View(programas);
        }

        // GET: Programa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programas programas = db.Programas.Find(id);
            if (programas == null)
            {
                return HttpNotFound();
            }
            return View(programas);
        }

        // POST: Programa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programas programas = db.Programas.Find(id);
            db.Programas.Remove(programas);
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
