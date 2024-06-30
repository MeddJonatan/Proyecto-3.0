using Proyecto.DAL.Context;
using Proyecto.Model.Clases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBD_3._0.Controllers
{
    public class CategoriasProductosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: CategoriasProductos
        public async Task<ActionResult> Index()
        {
            return View(await db.CategoriasProductos.ToListAsync());
        }

        // GET: CategoriasProductos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoriasProductos = await db.CategoriasProductos.FindAsync(id);
            if (categoriasProductos == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProductos);
        }

        // GET: CategoriasProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasProductos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_CategoriaProducto,Codigo_CategoriaProducto,Nombre_CategoriaProducto")] CategoriasProductos categoriasProductos)
        {
            if (ModelState.IsValid)
            {
                if (!await IsUniqueCodigoAndNombre(categoriasProductos))
                {
                    return View(categoriasProductos);
                }

                db.CategoriasProductos.Add(categoriasProductos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoriasProductos);
        }

        // GET: CategoriasProductos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoriasProductos = await db.CategoriasProductos.FindAsync(id);
            if (categoriasProductos == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProductos);
        }

        // POST: CategoriasProductos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_CategoriaProducto,Codigo_CategoriaProducto,Nombre_CategoriaProducto")] CategoriasProductos categoriasProductos)
        {
            if (ModelState.IsValid)
            {
                if (!await IsUniqueCodigoAndNombre(categoriasProductos, isEdit: true))
                {
                    return View(categoriasProductos);
                }

                db.Entry(categoriasProductos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoriasProductos);
        }

        // GET: CategoriasProductos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoriasProductos = await db.CategoriasProductos.FindAsync(id);
            if (categoriasProductos == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProductos);
        }

        // POST: CategoriasProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var categoriasProductos = await db.CategoriasProductos.FindAsync(id);
            db.CategoriasProductos.Remove(categoriasProductos);
            await db.SaveChangesAsync();
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

        private async Task<bool> IsUniqueCodigoAndNombre(CategoriasProductos categoriasProductos, bool isEdit = false)
        {
            try
            {
                var existingCodigo = await db.CategoriasProductos
                    .FirstOrDefaultAsync(c => c.Codigo_CategoriaProducto == categoriasProductos.Codigo_CategoriaProducto && (!isEdit || c.ID_CategoriaProducto != categoriasProductos.ID_CategoriaProducto));
                if (existingCodigo != null)
                {
                    ModelState.AddModelError("Codigo_CategoriaProducto", "Ya existe una categoría con este código.");
                    return false;
                }

                var existingNombre = await db.CategoriasProductos
                    .FirstOrDefaultAsync(c => c.Nombre_CategoriaProducto == categoriasProductos.Nombre_CategoriaProducto && (!isEdit || c.ID_CategoriaProducto != categoriasProductos.ID_CategoriaProducto));
                if (existingNombre != null)
                {
                    ModelState.AddModelError("Nombre_CategoriaProducto", "Ya existe una categoría con este nombre.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al verificar la unicidad de los datos. Intente nuevamente.");
                return false;
            }
        }
    }
}