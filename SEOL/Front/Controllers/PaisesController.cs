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
    public class PaisesController : Controller
    {
        private BD_SEOL2Entities1 db = new BD_SEOL2Entities1();

        // GET: /Paises/
        public ActionResult Index()
        {
            return View(db.Paises.ToList());
        }

        // GET: /Paises/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = db.Paises.Find(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // GET: /Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Paises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="cod_pais,nom_pais")] Paises paises)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Add(paises);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paises);
        }

        // GET: /Paises/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = db.Paises.Find(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // POST: /Paises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="cod_pais,nom_pais")] Paises paises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paises).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paises);
        }

        // GET: /Paises/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = db.Paises.Find(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // POST: /Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Paises paises = db.Paises.Find(id);
            db.Paises.Remove(paises);
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
