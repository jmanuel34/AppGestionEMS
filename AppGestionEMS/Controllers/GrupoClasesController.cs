using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppGestionEMS.Models;

namespace AppGestionEMS.Controllers
{
  
    public class GrupoClasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GrupoClases

    [Authorize (Roles = "administrador, profesor")]
        public ActionResult Index()
        {
            return View(db.GrupoClases.ToList());
        }

        // GET: GrupoClases/Details/5
        [Authorize(Roles = "administrador, profesor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClase grupoClase = db.GrupoClases.Find(id);
            if (grupoClase == null)
            {
                return HttpNotFound();
            }
            return View(grupoClase);
        }

        // GET: GrupoClases/Create
        [Authorize(Roles = "administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoClases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador")]
        public ActionResult Create([Bind(Include = "Id,denominacion")] GrupoClase grupoClase)
        {
            if (ModelState.IsValid)
            {
                db.GrupoClases.Add(grupoClase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoClase);
        }

        // GET: GrupoClases/Edit/5
        [Authorize(Roles ="administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClase grupoClase = db.GrupoClases.Find(id);
            if (grupoClase == null)
            {
                return HttpNotFound();
            }
            return View(grupoClase);
        }

        // POST: GrupoClases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador")]
        public ActionResult Edit([Bind(Include = "Id,denominacion")] GrupoClase grupoClase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoClase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoClase);
        }

        // GET: GrupoClases/Delete/5
        [Authorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClase grupoClase = db.GrupoClases.Find(id);
            if (grupoClase == null)
            {
                return HttpNotFound();
            }
            return View(grupoClase);
        }

        // POST: GrupoClases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoClase grupoClase = db.GrupoClases.Find(id);
            db.GrupoClases.Remove(grupoClase);
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
