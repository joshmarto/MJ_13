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
    public class TipoMController : Controller
    {
        private Contexto db = new Contexto();

        // GET: TipoM
        public ActionResult Index()
        {
            return View(db.TipoMs.ToList());
        }

        // GET: TipoM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoM tipoM = db.TipoMs.Find(id);
            if (tipoM == null)
            {
                return HttpNotFound();
            }
            return View(tipoM);
        }

        // GET: TipoM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoM/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo")] TipoM tipoM)
        {
            if (ModelState.IsValid)
            {
                db.TipoMs.Add(tipoM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoM);
        }

        // GET: TipoM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoM tipoM = db.TipoMs.Find(id);
            if (tipoM == null)
            {
                return HttpNotFound();
            }
            return View(tipoM);
        }

        // POST: TipoM/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo")] TipoM tipoM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoM);
        }

        // GET: TipoM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoM tipoM = db.TipoMs.Find(id);
            if (tipoM == null)
            {
                return HttpNotFound();
            }
            return View(tipoM);
        }

        // POST: TipoM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoM tipoM = db.TipoMs.Find(id);
            db.TipoMs.Remove(tipoM);
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
