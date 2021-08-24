using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolNewHope.Models;

namespace SchoolNewHope.Controllers
{
    public class AlumnoGradosController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AlumnoGrados
        public ActionResult Index()
        {
            var alumnoGrados = db.AlumnoGrados.Include(a => a.Alumno).Include(a => a.Grado);
            return View(alumnoGrados.ToList());
        }

        // GET: AlumnoGrados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnoGrados.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }
            return View(alumnoGrado);
        }

        // GET: AlumnoGrados/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "NumeroIdentidad");
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre");
            return View();
        }

        // POST: AlumnoGrados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlumnoId,GradoId,GradoActual")] AlumnoGrado alumnoGrado)
        {
            if (ModelState.IsValid)
            {
                db.AlumnoGrados.Add(alumnoGrado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "NumeroIdentidad", alumnoGrado.AlumnoId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        // GET: AlumnoGrados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnoGrados.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "NumeroIdentidad", alumnoGrado.AlumnoId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        // POST: AlumnoGrados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlumnoId,GradoId,GradoActual")] AlumnoGrado alumnoGrado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnoGrado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "NumeroIdentidad", alumnoGrado.AlumnoId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        // GET: AlumnoGrados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnoGrados.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }
            return View(alumnoGrado);
        }

        // POST: AlumnoGrados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlumnoGrado alumnoGrado = db.AlumnoGrados.Find(id);
            db.AlumnoGrados.Remove(alumnoGrado);
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
