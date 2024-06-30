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
    public class ClientesController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes
                .Include(e => e.Generos)
                .Include(e => e.NumerosTelefonicos)
                .Include(e => e.Salidas);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes
                .Include(e => e.Generos)
                .Include(e => e.NumerosTelefonicos)
                .Include(e => e.Salidas)
                .FirstOrDefault(e => e.ID_Cliente == id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            PopulateDropDownLists();
            ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre");
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cliente, NO_Cliente, ID_DatoUsuario")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.Clientes.Any(e => e.NO_Cliente == clientes.NO_Cliente))
                    {
                        ModelState.AddModelError("NO_Cliente", "El número de cliente ya existe.");
                        PopulateDropDownLists();
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", clientes.ID_DatoUsuario);
                        return View(clientes);
                    }

                    var usuario = db.DatosUsuarios.Find(clientes.ID_DatoUsuario);
                    if (usuario == null)
                    {
                        ModelState.AddModelError("ID_DatoUsuario", "El usuario seleccionado no existe.");
                        PopulateDropDownLists();
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", clientes.ID_DatoUsuario);
                        return View(clientes);
                    }

                    clientes.PrimerNombre = usuario.PrimerNombre;
                    clientes.SegundoNombre = usuario.SegundoNombre;
                    clientes.PrimerApellido = usuario.PrimerApellido;
                    clientes.SegundoApellido = usuario.SegundoApellido;
                    clientes.Edad = usuario.Edad;
                    clientes.ID_NumTelefono = usuario.ID_NumTelefono;
                    clientes.ID_Genero = usuario.ID_Genero;

                    db.Clientes.Add(clientes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el cliente: " + ex.Message);
                }
            }
            PopulateDropDownLists();
            ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", clientes.ID_DatoUsuario);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes
                .Include(e => e.Generos)
                .Include(e => e.NumerosTelefonicos)
                .Include(e => e.Salidas)
                .FirstOrDefault(e => e.ID_Cliente == id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownLists(clientes.ID_Genero, clientes.ID_NumTelefono);
            ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", clientes.ID_DatoUsuario);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cliente,NO_Cliente,ID_DatoUsuario")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.Clientes.Any(e => e.NO_Cliente == clientes.NO_Cliente && e.ID_Cliente != clientes.ID_Cliente))
                    {
                        ModelState.AddModelError("NO_Cliente", "El número de cliente ya existe.");
                        PopulateDropDownLists(clientes.ID_Genero, clientes.ID_NumTelefono);
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", clientes.ID_DatoUsuario);
                        return View(clientes);
                    }

                    var usuario = db.DatosUsuarios.Find(clientes.ID_DatoUsuario);
                    if (usuario == null)
                    {
                        ModelState.AddModelError("ID_DatoUsuario", "El usuario seleccionado no existe.");
                        PopulateDropDownLists(clientes.ID_Genero, clientes.ID_NumTelefono);
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", clientes.ID_DatoUsuario);
                        return View(clientes);
                    }

                    clientes.PrimerNombre = usuario.PrimerNombre;
                    clientes.SegundoNombre = usuario.SegundoNombre;
                    clientes.PrimerApellido = usuario.PrimerApellido;
                    clientes.SegundoApellido = usuario.SegundoApellido;
                    clientes.Edad = usuario.Edad;
                    clientes.ID_NumTelefono = usuario.ID_NumTelefono;
                    clientes.ID_Genero = usuario.ID_Genero;

                    db.Entry(clientes).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al editar el cliente: " + ex.Message);
                }
            }
            PopulateDropDownLists(clientes.ID_Genero, clientes.ID_NumTelefono);
            ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", clientes.ID_DatoUsuario);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes
                .Include(e => e.Generos)
                .Include(e => e.NumerosTelefonicos)
                .Include(e => e.Salidas)
                .FirstOrDefault(e => e.ID_Cliente == id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Clientes clientes = db.Clientes.Find(id);
                db.Clientes.Remove(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar el cliente: " + ex.Message);
                return RedirectToAction("Delete", new { id });
            }
        }

        private void PopulateDropDownLists(int? selectedGender = null, int? selectedPhone = null)
        {
            ViewBag.ID_Genero = new SelectList(db.Generos, "ID_Genero", "Descripcion_Genero", selectedGender);
            ViewBag.ID_NumTelefono = new SelectList(db.NumerosTelefonicos, "ID_NumTelefono", "NumeroTelefono", selectedPhone);
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