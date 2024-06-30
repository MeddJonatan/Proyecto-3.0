using Proyecto.DAL.Context;
using Proyecto.Model.Clases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBD_3._0.Controllers
{
    public class PaisesController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Paises
        public async Task<ActionResult> Index()
        {
            return View(await db.Paises.ToListAsync());
        }

        // GET: Paises/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "El ID no puede ser nulo.");
            }

            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return HttpNotFound("No se encontró el país con el ID especificado.");
            }
            return View(paises);
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Codigo_Pais,Nombre_Pais,Nacionalidad,Sufijo_Pais")] Paises paises)
        {
            if (!ModelState.IsValid)
            {
                return View(paises);
            }

            if (await IsUniqueCodigoAndNombre(paises))
            {
                db.Paises.Add(paises);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "El código o nombre del país ya existe.");
            return View(paises);
        }

        // GET: Paises/Edit/5
        public async Task <ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "El ID no puede ser nulo.");
            }

            var paises =  await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return HttpNotFound("No se encontró el país con el ID especificado.");
            }
            return View(paises);
        }

        // POST: Paises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Codigo_Pais,Nombre_Pais,Nacionalidad,Sufijo_Pais")] Paises paises)
        {
            if (ModelState.IsValid)
            {
                if (!await IsUniqueCodigoAndNombre(paises))
                {
                    return View(paises);
                }

                try
                {
                    db.Entry(paises).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.Single();
                    var clientValues = (Paises)entry.Entity;
                    var databaseEntry = await entry.GetDatabaseValuesAsync();
                    if (databaseEntry == null)
                    {
                        // La entidad ha sido eliminada por otro usuario
                        ModelState.AddModelError(string.Empty, "No se pueden guardar los cambios. El país fue eliminado por otro usuario.");
                    }
                    else
                    {
                        // La entidad ha sido actualizada por otro usuario
                        var databaseValues = (Paises)databaseEntry.ToObject();
                        ModelState.AddModelError(string.Empty, "ERROR");

                        // Actualiza los valores originales con los valores de la base de datos
                        entry.OriginalValues.SetValues(databaseValues);
                        entry.CurrentValues.SetValues(clientValues);
                    }
                }
            }
            return View(paises);
        }

        private async Task<bool> IsUniqueCodigoAndNombre(Paises paises, string codigo_Pais, int? id = null)
        {
            return !await db.Paises.AnyAsync(p => p.Codigo_Pais == paises.Codigo_Pais && p.Nombre_Pais == paises.Nombre_Pais && p.ID_Pais != id);
        }

        // GET: Paises/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "El ID no puede ser nulo.");
            }

            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return HttpNotFound("No se encontró el país con el ID especificado.");
            }
            return View(paises);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            Paises paises = await db.Paises.FindAsync(id);
            db.Paises.Remove(paises);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private async Task<bool> IsUniqueCodigoAndNombre(Paises paises, int? id = null)
        {
            return !await db.Paises.AnyAsync(p => p.Codigo_Pais == paises.Codigo_Pais && p.Nombre_Pais == paises.Nombre_Pais && p.ID_Pais != id);
        }
    }
}