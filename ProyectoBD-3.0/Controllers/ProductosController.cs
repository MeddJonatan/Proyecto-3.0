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
    public class ProductosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.CategoriasProductos).Include(p => p.MarcasProductos).Include(p => p.UnidadesMedidas);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.ID_CategoriaProducto = new SelectList(db.CategoriasProductos, "ID_CategoriaProducto", "Codigo_CategoriaProducto");
            ViewBag.ID_MarcaProducto = new SelectList(db.MarcasProductos, "ID_MarcaProducto", "Codigo_MarcaProducto");
            ViewBag.ID_UnidadMedida = new SelectList(db.UnidadesMedidas, "ID_UnidadMedida", "Abreviatura_UnidadMedida");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Producto,Codigo_Producto,NombreProducto,ID_CategoriaProducto,ID_MarcaProducto,ID_UnidadMedida")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CategoriaProducto = new SelectList(db.CategoriasProductos, "ID_CategoriaProducto", "Codigo_CategoriaProducto", productos.ID_CategoriaProducto);
            ViewBag.ID_MarcaProducto = new SelectList(db.MarcasProductos, "ID_MarcaProducto", "Codigo_MarcaProducto", productos.ID_MarcaProducto);
            ViewBag.ID_UnidadMedida = new SelectList(db.UnidadesMedidas, "ID_UnidadMedida", "Abreviatura_UnidadMedida", productos.ID_UnidadMedida);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CategoriaProducto = new SelectList(db.CategoriasProductos, "ID_CategoriaProducto", "Codigo_CategoriaProducto", productos.ID_CategoriaProducto);
            ViewBag.ID_MarcaProducto = new SelectList(db.MarcasProductos, "ID_MarcaProducto", "Codigo_MarcaProducto", productos.ID_MarcaProducto);
            ViewBag.ID_UnidadMedida = new SelectList(db.UnidadesMedidas, "ID_UnidadMedida", "Abreviatura_UnidadMedida", productos.ID_UnidadMedida);
            return View(productos);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Producto,Codigo_Producto,NombreProducto,ID_CategoriaProducto,ID_MarcaProducto,ID_UnidadMedida")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CategoriaProducto = new SelectList(db.CategoriasProductos, "ID_CategoriaProducto", "Codigo_CategoriaProducto", productos.ID_CategoriaProducto);
            ViewBag.ID_MarcaProducto = new SelectList(db.MarcasProductos, "ID_MarcaProducto", "Codigo_MarcaProducto", productos.ID_MarcaProducto);
            ViewBag.ID_UnidadMedida = new SelectList(db.UnidadesMedidas, "ID_UnidadMedida", "Abreviatura_UnidadMedida", productos.ID_UnidadMedida);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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