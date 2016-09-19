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
    public class TipoUsuariosController : Controller
    {
        private BD_SEOL2Entities1 db = new BD_SEOL2Entities1();

        // GET: /TipoUsuarios/
        public ActionResult Index()
        {
            return View(db.TipoUsuarios.ToList());
        }

        // GET: /TipoUsuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipousuarios = db.TipoUsuarios.Find(id);
            if (tipousuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipousuarios);
        }

        // GET: /TipoUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="tip_usu,des_usu")] TipoUsuarios tipousuarios)
        {
            if (ModelState.IsValid)
            {
                db.TipoUsuarios.Add(tipousuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipousuarios);
        }

        // GET: /TipoUsuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipousuarios = db.TipoUsuarios.Find(id);
            if (tipousuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipousuarios);
        }

        // POST: /TipoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="tip_usu,des_usu")] TipoUsuarios tipousuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipousuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipousuarios);
        }

        // GET: /TipoUsuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipousuarios = db.TipoUsuarios.Find(id);
            if (tipousuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipousuarios);
        }

        // POST: /TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TipoUsuarios tipousuarios = db.TipoUsuarios.Find(id);
            db.TipoUsuarios.Remove(tipousuarios);
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
