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
    public class LideresVController : Controller
    {
        private Contexto db = new Contexto();

        // GET: LideresV
        public ActionResult Index()
        {
            return View(db.LideresVs.ToList());
        }

        // GET: LideresV/Details/5
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

        // GET: LideresV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LideresV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: LideresV/Edit/5
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

        // POST: LideresV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: LideresV/Delete/5
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

        // POST: LideresV/Delete/5
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
