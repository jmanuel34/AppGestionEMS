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
 
    public class AsignacionDocentesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignacionDocentes
        [Authorize(Roles = " administrador,profesor")]
        public ActionResult Index()
        {
            var asignacionDocentes = db.AsignacionDocentes.Include(a => a.Curso).Include(a => a.GrupoClase).Include(a => a.User);
            return View(asignacionDocentes.ToList());
        }

        // GET: AsignacionDocentes/Details/5
        [Authorize(Roles = " administrador,profesor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocentes asignacionDocentes = db.AsignacionDocentes.Find(id);
            if (asignacionDocentes == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocentes);
        }

        // GET: AsignacionDocentes/Create
        [Authorize(Roles = " administrador")]
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "nombre");
            ViewBag.GrupoClaseId = new SelectList(db.GrupoClases, "Id", "nombre");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: AsignacionDocentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = " administrador")]
        public ActionResult Create([Bind(Include = "Id,UserId,GrupoClaseId,CursoId")] AsignacionDocentes asignacionDocentes)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionDocentes.Add(asignacionDocentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "nombre", asignacionDocentes.CursoId);
            ViewBag.GrupoClaseId = new SelectList(db.GrupoClases, "Id", "nombre", asignacionDocentes.GrupoClaseId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocentes.UserId);
            return View(asignacionDocentes);
        }

        // GET: AsignacionDocentes/Edit/5
        [Authorize(Roles = " administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocentes asignacionDocentes = db.AsignacionDocentes.Find(id);
            if (asignacionDocentes == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "nombre", asignacionDocentes.CursoId);
            ViewBag.GrupoClaseId = new SelectList(db.GrupoClases, "Id", "nombre", asignacionDocentes.GrupoClaseId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocentes.UserId);
            return View(asignacionDocentes);
        }

        // POST: AsignacionDocentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = " administrador")]
        public ActionResult Edit([Bind(Include = "Id,UserId,GrupoClaseId,CursoId")] AsignacionDocentes asignacionDocentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionDocentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "nombre", asignacionDocentes.CursoId);
            ViewBag.GrupoClaseId = new SelectList(db.GrupoClases, "Id", "nombre", asignacionDocentes.GrupoClaseId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocentes.UserId);
            return View(asignacionDocentes);
        }

        // GET: AsignacionDocentes/Delete/5
        [Authorize(Roles = " administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocentes asignacionDocentes = db.AsignacionDocentes.Find(id);
            if (asignacionDocentes == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocentes);
        }

        // POST: AsignacionDocentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = " administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionDocentes asignacionDocentes = db.AsignacionDocentes.Find(id);
            db.AsignacionDocentes.Remove(asignacionDocentes);
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
