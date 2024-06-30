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
    public class MarcasProductosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: MarcasProductos
        public ActionResult Index()
        {
            return View(db.MarcasProductos.ToList());
        }

        // GET: MarcasProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcasProductos marcasProductos = db.MarcasProductos.Find(id);
            if (marcasProductos == null)
            {
                return HttpNotFound();
            }
            return View(marcasProductos);
        }

        // GET: MarcasProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarcasProductos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MarcaProducto,Codigo_MarcaProducto,Nombre_MarcaProducto")] MarcasProductos marcasProductos)
        {
            if (ModelState.IsValid)
            {
                db.MarcasProductos.Add(marcasProductos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marcasProductos);
        }

        // GET: MarcasProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcasProductos marcasProductos = db.MarcasProductos.Find(id);
            if (marcasProductos == null)
            {
                return HttpNotFound();
            }
            return View(marcasProductos);
        }

        // POST: MarcasProductos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MarcaProducto,Codigo_MarcaProducto,Nombre_MarcaProducto")] MarcasProductos marcasProductos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcasProductos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marcasProductos);
        }

        // GET: MarcasProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcasProductos marcasProductos = db.MarcasProductos.Find(id);
            if (marcasProductos == null)
            {
                return HttpNotFound();
            }
            return View(marcasProductos);
        }

        // POST: MarcasProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            MarcasProductos marcasProductos = db.MarcasProductos.Find(id);
            db.MarcasProductos.Remove(marcasProductos);
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