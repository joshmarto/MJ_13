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
    public class LiderVController : Controller
    {
        private Contexto db = new Contexto();

        // GET: LiderV
        public ActionResult Index()
        {
            return View(db.LideresVs.ToList());
        }

        // GET: LiderV/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LideresV lideresV = db.LideresVs.Find(id);
            if (lideresV == null)
            {
                return HttpNotFound();
            }
            return View(lideresV);
        }

        // GET: LiderV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LiderV/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Telefono,Email")] LideresV lideresV)
        {
            if (ModelState.IsValid)
            {
                db.LideresVs.Add(lideresV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lideresV);
        }

        // GET: LiderV/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LideresV lideresV = db.LideresVs.Find(id);
            if (lideresV == null)
            {
                return HttpNotFound();
            }
            return View(lideresV);
        }

        // POST: LiderV/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Telefono,Email")] LideresV lideresV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lideresV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lideresV);
        }

        // GET: LiderV/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LideresV lideresV = db.LideresVs.Find(id);
            if (lideresV == null)
            {
                return HttpNotFound();
            }
            return View(lideresV);
        }

        // POST: LiderV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LideresV lideresV = db.LideresVs.Find(id);
            db.LideresVs.Remove(lideresV);
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
