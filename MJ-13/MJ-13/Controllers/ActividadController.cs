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
    public class ActividadController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Actividad
        public ActionResult Index()
        {
            var actividades = db.Actividades.Include(a => a.Leader).Include(a => a.Lider).Include(a => a.Predicador).Include(a => a.Programa);
            return View(actividades.ToList());
        }

        // GET: Actividad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            ViewBag.LeaderID = new SelectList(db.Miembros, "ID", "Nombre");
            ViewBag.LiderID = new SelectList(db.Lideres, "ID", "Nombre");
            ViewBag.PredicadorID = new SelectList(db.Predicadores, "ID", "Nombre");
            ViewBag.ProgramaID = new SelectList(db.Programas, "ID", "Programa");
            return View();
        }

        // POST: Actividad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Numero,Fecha,Medio,Actividad,LiderID,ActividadL,LeaderID,PredicadorID,Tema,CitaBase,NoParticipantes,ProgramaID,Realizada,Observaciones")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                db.Actividades.Add(actividades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeaderID = new SelectList(db.Miembros, "ID", "Nombre", actividades.LeaderID);
            ViewBag.LiderID = new SelectList(db.Lideres, "ID", "Nombre", actividades.LiderID);
            ViewBag.PredicadorID = new SelectList(db.Predicadores, "ID", "Nombre", actividades.PredicadorID);
            ViewBag.ProgramaID = new SelectList(db.Programas, "ID", "Programa", actividades.ProgramaID);
            return View(actividades);
        }

        // GET: Actividad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeaderID = new SelectList(db.Miembros, "ID", "Nombre", actividades.LeaderID);
            ViewBag.LiderID = new SelectList(db.Lideres, "ID", "Nombre", actividades.LiderID);
            ViewBag.PredicadorID = new SelectList(db.Predicadores, "ID", "Nombre", actividades.PredicadorID);
            ViewBag.ProgramaID = new SelectList(db.Programas, "ID", "Programa", actividades.ProgramaID);
            return View(actividades);
        }

        // POST: Actividad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Numero,Fecha,Medio,Actividad,LiderID,ActividadL,LeaderID,PredicadorID,Tema,CitaBase,NoParticipantes,ProgramaID,Realizada,Observaciones")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeaderID = new SelectList(db.Miembros, "ID", "Nombre", actividades.LeaderID);
            ViewBag.LiderID = new SelectList(db.Lideres, "ID", "Nombre", actividades.LiderID);
            ViewBag.PredicadorID = new SelectList(db.Predicadores, "ID", "Nombre", actividades.PredicadorID);
            ViewBag.ProgramaID = new SelectList(db.Programas, "ID", "Programa", actividades.ProgramaID);
            return View(actividades);
        }

        // GET: Actividad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        // POST: Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividades actividades = db.Actividades.Find(id);
            db.Actividades.Remove(actividades);
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
