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
    public class TipoDocumentoIdentidadController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: TipoDocumentoIdentidads
        public ActionResult Index()
        {
            var tipo_DocumentoIdentidad = db.Tipo_DocumentoIdentidad.Include(t => t.Paises);
            return View(tipo_DocumentoIdentidad.ToList());
        }

        // GET: TipoDocumentoIdentidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumentoIdentidad tipoDocumentoIdentidad = db.Tipo_DocumentoIdentidad.Find(id);
            if (tipoDocumentoIdentidad == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumentoIdentidad);
        }

        // GET: TipoDocumentoIdentidads/Create
        public ActionResult Create()
        {
            ViewBag.ID_Pais = new SelectList(db.Paises, "ID_Pais", "Codigo_Pais");
            return View();
        }

        // POST: TipoDocumentoIdentidads/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TipoDocumentoIdentidad,Codigo_TipoDocumento,Descripcion_TipoDocumentoIdentidad,ID_Pais")] TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_DocumentoIdentidad.Add(tipoDocumentoIdentidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Pais = new SelectList(db.Paises, "ID_Pais", "Codigo_Pais", tipoDocumentoIdentidad.ID_Pais);
            return View(tipoDocumentoIdentidad);
        }

        // GET: TipoDocumentoIdentidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumentoIdentidad tipoDocumentoIdentidad = db.Tipo_DocumentoIdentidad.Find(id);
            if (tipoDocumentoIdentidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Pais = new SelectList(db.Paises, "ID_Pais", "Codigo_Pais", tipoDocumentoIdentidad.ID_Pais);
            return View(tipoDocumentoIdentidad);
        }

        // POST: TipoDocumentoIdentidads/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TipoDocumentoIdentidad,Codigo_TipoDocumento,Descripcion_TipoDocumentoIdentidad,ID_Pais")] TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDocumentoIdentidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Pais = new SelectList(db.Paises, "ID_Pais", "Codigo_Pais", tipoDocumentoIdentidad.ID_Pais);
            return View(tipoDocumentoIdentidad);
        }

        // GET: TipoDocumentoIdentidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumentoIdentidad tipoDocumentoIdentidad = db.Tipo_DocumentoIdentidad.Find(id);
            if (tipoDocumentoIdentidad == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumentoIdentidad);
        }

        // POST: TipoDocumentoIdentidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            TipoDocumentoIdentidad tipoDocumentoIdentidad = db.Tipo_DocumentoIdentidad.Find(id);
            db.Tipo_DocumentoIdentidad.Remove(tipoDocumentoIdentidad);
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