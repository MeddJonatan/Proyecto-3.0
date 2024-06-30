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
    public class DocumentoIdentidadController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: DocumentoIdentidads
        public ActionResult Index()
        {
            var documentoIdentidad = db.DocumentoIdentidad.Include(d => d.TipoDocumentoIdentidad);
            return View(documentoIdentidad.ToList());
        }

        // GET: DocumentoIdentidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentoIdentidad documentoIdentidad = db.DocumentoIdentidad.Find(id);
            if (documentoIdentidad == null)
            {
                return HttpNotFound();
            }
            return View(documentoIdentidad);
        }

        // GET: DocumentoIdentidads/Create
        public ActionResult Create()
        {
            ViewBag.ID_TipoDocumentoIdentidad = new SelectList(db.Tipo_DocumentoIdentidad, "ID_TipoDocumentoIdentidad", "Codigo_TipoDocumento");
            return View();
        }

        // POST: DocumentoIdentidads/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DocumentoIdentidad,Codigo_DocumentoIdentidad,FechaEmision_DocumentoIdentidad,FechaFinalizacion_DocumentoIdentidad,ID_TipoDocumentoIdentidad")] DocumentoIdentidad documentoIdentidad)
        {
            if (ModelState.IsValid)
            {
                db.DocumentoIdentidad.Add(documentoIdentidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TipoDocumentoIdentidad = new SelectList(db.Tipo_DocumentoIdentidad, "ID_TipoDocumentoIdentidad", "Codigo_TipoDocumento", documentoIdentidad.ID_TipoDocumentoIdentidad);
            return View(documentoIdentidad);
        }

        // GET: DocumentoIdentidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentoIdentidad documentoIdentidad = db.DocumentoIdentidad.Find(id);
            if (documentoIdentidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TipoDocumentoIdentidad = new SelectList(db.Tipo_DocumentoIdentidad, "ID_TipoDocumentoIdentidad", "Codigo_TipoDocumento", documentoIdentidad.ID_TipoDocumentoIdentidad);
            return View(documentoIdentidad);
        }

        // POST: DocumentoIdentidads/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DocumentoIdentidad,Codigo_DocumentoIdentidad,FechaEmision_DocumentoIdentidad,FechaFinalizacion_DocumentoIdentidad,ID_TipoDocumentoIdentidad")] DocumentoIdentidad documentoIdentidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentoIdentidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TipoDocumentoIdentidad = new SelectList(db.Tipo_DocumentoIdentidad, "ID_TipoDocumentoIdentidad", "Codigo_TipoDocumento", documentoIdentidad.ID_TipoDocumentoIdentidad);
            return View(documentoIdentidad);
        }

        // GET: DocumentoIdentidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentoIdentidad documentoIdentidad = db.DocumentoIdentidad.Find(id);
            if (documentoIdentidad == null)
            {
                return HttpNotFound();
            }
            return View(documentoIdentidad);
        }

        // POST: DocumentoIdentidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DocumentoIdentidad documentoIdentidad = db.DocumentoIdentidad.Find(id);
            db.DocumentoIdentidad.Remove(documentoIdentidad);
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
