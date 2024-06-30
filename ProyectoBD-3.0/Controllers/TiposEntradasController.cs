using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.DAL.Context;
using Proyecto.Model.Clases;

namespace ProyectoBD_3._0.Controllers
{
    public class TiposEntradasController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: TiposEntradas
        public ActionResult Index()
        {
            return View(db.TiposEntradas.ToList());
        }

        // GET: TiposEntradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposEntradas tiposEntradas = db.TiposEntradas.Find(id);
            if (tiposEntradas == null)
            {
                return HttpNotFound();
            }
            return View(tiposEntradas);
        }

        // GET: TiposEntradas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposEntradas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TipoEntrada,Codigo_TipoEntrada,Descripcion_TipoEntrada")] TiposEntradas tiposEntradas)
        {
            if (ModelState.IsValid)
            {
                db.TiposEntradas.Add(tiposEntradas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposEntradas);
        }

        // GET: TiposEntradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposEntradas tiposEntradas = db.TiposEntradas.Find(id);
            if (tiposEntradas == null)
            {
                return HttpNotFound();
            }
            return View(tiposEntradas);
        }

        // POST: TiposEntradas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TipoEntrada,Codigo_TipoEntrada,Descripcion_TipoEntrada")] TiposEntradas tiposEntradas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposEntradas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposEntradas);
        }

        // GET: TiposEntradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposEntradas tiposEntradas = db.TiposEntradas.Find(id);
            if (tiposEntradas == null)
            {
                return HttpNotFound();
            }
            return View(tiposEntradas);
        }

        // POST: TiposEntradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            TiposEntradas tiposEntradas = db.TiposEntradas.Find(id);
            db.TiposEntradas.Remove(tiposEntradas);
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