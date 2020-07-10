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
    public class MiembroController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Miembro
        public ActionResult Index()
        {
            return View(db.Miembros.ToList());
        }

        // GET: Miembro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = db.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            return View(miembros);
        }

        // GET: Miembro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Miembro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Telefono,Email,Activo")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                db.Miembros.Add(miembros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miembros);
        }

        // GET: Miembro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = db.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            return View(miembros);
        }

        // POST: Miembro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Telefono,Email,Activo")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miembros);
        }

        // GET: Miembro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembros miembros = db.Miembros.Find(id);
            if (miembros == null)
            {
                return HttpNotFound();
            }
            return View(miembros);
        }

        // POST: Miembro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembros miembros = db.Miembros.Find(id);
            db.Miembros.Remove(miembros);
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
