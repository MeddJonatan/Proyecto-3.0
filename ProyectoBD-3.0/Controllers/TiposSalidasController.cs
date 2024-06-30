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
    public class TiposSalidasController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: TiposSalidas
        public ActionResult Index()
        {
            return View(db.TiposSalidas.ToList());
        }

        // GET: TiposSalidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposSalidas tiposSalidas = db.TiposSalidas.Find(id);
            if (tiposSalidas == null)
            {
                return HttpNotFound();
            }
            return View(tiposSalidas);
        }

        // GET: TiposSalidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposSalidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TipoSalida,Codigo_TipoSalida,Descripcion_TipoSalida")] TiposSalidas tiposSalidas)
        {
            if (ModelState.IsValid)
            {
                db.TiposSalidas.Add(tiposSalidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposSalidas);
        }

        // GET: TiposSalidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposSalidas tiposSalidas = db.TiposSalidas.Find(id);
            if (tiposSalidas == null)
            {
                return HttpNotFound();
            }
            return View(tiposSalidas);
        }

        // POST: TiposSalidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TipoSalida,Codigo_TipoSalida,Descripcion_TipoSalida")] TiposSalidas tiposSalidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposSalidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposSalidas);
        }

        // GET: TiposSalidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposSalidas tiposSalidas = db.TiposSalidas.Find(id);
            if (tiposSalidas == null)
            {
                return HttpNotFound();
            }
            return View(tiposSalidas);
        }

        // POST: TiposSalidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            TiposSalidas tiposSalidas = db.TiposSalidas.Find(id);
            db.TiposSalidas.Remove(tiposSalidas);
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
