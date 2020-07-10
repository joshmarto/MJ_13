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
    public class LiderController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Lider
        public ActionResult Index()
        {
            return View(db.Lideres.ToList());
        }

        // GET: Lider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lideres lideres = db.Lideres.Find(id);
            if (lideres == null)
            {
                return HttpNotFound();
            }
            return View(lideres);
        }

        // GET: Lider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lider/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Telefono,Email")] Lideres lideres)
        {
            if (ModelState.IsValid)
            {
                db.Lideres.Add(lideres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lideres);
        }

        // GET: Lider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lideres lideres = db.Lideres.Find(id);
            if (lideres == null)
            {
                return HttpNotFound();
            }
            return View(lideres);
        }

        // POST: Lider/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Telefono,Email")] Lideres lideres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lideres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lideres);
        }

        // GET: Lider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lideres lideres = db.Lideres.Find(id);
            if (lideres == null)
            {
                return HttpNotFound();
            }
            return View(lideres);
        }

        // POST: Lider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lideres lideres = db.Lideres.Find(id);
            db.Lideres.Remove(lideres);
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
