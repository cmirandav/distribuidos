using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Front.Models;

namespace Front.Controllers
{
    public class UbigeosController : Controller
    {
        private BD_SEOL2Entities1 db = new BD_SEOL2Entities1();

        // GET: /Ubigeos/
        public ActionResult Index()
        {
            return View(db.Ubigeos.ToList());
        }

        // GET: /Ubigeos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeos ubigeos = db.Ubigeos.Find(id);
            if (ubigeos == null)
            {
                return HttpNotFound();
            }
            return View(ubigeos);
        }

        // GET: /Ubigeos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ubigeos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="cod_ubi_geo,nom_dep,nom_prv,nom_dis")] Ubigeos ubigeos)
        {
            if (ModelState.IsValid)
            {
                db.Ubigeos.Add(ubigeos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ubigeos);
        }

        // GET: /Ubigeos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeos ubigeos = db.Ubigeos.Find(id);
            if (ubigeos == null)
            {
                return HttpNotFound();
            }
            return View(ubigeos);
        }

        // POST: /Ubigeos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="cod_ubi_geo,nom_dep,nom_prv,nom_dis")] Ubigeos ubigeos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ubigeos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ubigeos);
        }

        // GET: /Ubigeos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeos ubigeos = db.Ubigeos.Find(id);
            if (ubigeos == null)
            {
                return HttpNotFound();
            }
            return View(ubigeos);
        }

        // POST: /Ubigeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ubigeos ubigeos = db.Ubigeos.Find(id);
            db.Ubigeos.Remove(ubigeos);
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
