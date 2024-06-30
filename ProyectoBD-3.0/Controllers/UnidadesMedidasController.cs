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
    public class UnidadesMedidasController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: UnidadesMedidas
        public ActionResult Index()
        {
            return View(db.UnidadesMedidas.ToList());
        }

        // GET: UnidadesMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadesMedidas unidadesMedidas = db.UnidadesMedidas.Find(id);
            if (unidadesMedidas == null)
            {
                return HttpNotFound();
            }
            return View(unidadesMedidas);
        }

        // GET: UnidadesMedidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadesMedidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_UnidadMedida,Abreviatura_UnidadMedida,Descripcion_UnidadMedida")] UnidadesMedidas unidadesMedidas)
        {
            if (ModelState.IsValid)
            {
                db.UnidadesMedidas.Add(unidadesMedidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadesMedidas);
        }

        // GET: UnidadesMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadesMedidas unidadesMedidas = db.UnidadesMedidas.Find(id);
            if (unidadesMedidas == null)
            {
                return HttpNotFound();
            }
            return View(unidadesMedidas);
        }

        // POST: UnidadesMedidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_UnidadMedida,Abreviatura_UnidadMedida,Descripcion_UnidadMedida")] UnidadesMedidas unidadesMedidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadesMedidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadesMedidas);
        }

        // GET: UnidadesMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadesMedidas unidadesMedidas = db.UnidadesMedidas.Find(id);
            if (unidadesMedidas == null)
            {
                return HttpNotFound();
            }
            return View(unidadesMedidas);
        }

        // POST: UnidadesMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            UnidadesMedidas unidadesMedidas = db.UnidadesMedidas.Find(id);
            db.UnidadesMedidas.Remove(unidadesMedidas);
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