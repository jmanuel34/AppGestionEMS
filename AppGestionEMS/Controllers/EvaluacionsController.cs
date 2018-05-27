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
    public class EvaluacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Evaluacions
        [Authorize(Roles = "administrador, profesor, alumno")]
        public ActionResult Index()
        {
            return View(db.Evaluacions.ToList());
        }

        // GET: Evaluacions/Details/5
        [Authorize(Roles = "administrador, profesor, alumno")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacions.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        [Authorize(Roles = "administrador, profesor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador, profesor")]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,nota_Pr,nota_Ev,nota_P1,nota_P2,nota_P3,nota_P4,nota_Final,practica_Convalidada,examen_Convalidado")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Evaluacions.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        [Authorize(Roles = "administrador, profesor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacions.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador, profesor")]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,nota_Pr,nota_Ev,nota_P1,nota_P2,nota_P3,nota_P4,nota_Final,practica_Convalidada,examen_Convalidado")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        [Authorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacions.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = db.Evaluacions.Find(id);
            db.Evaluacions.Remove(evaluacion);
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
