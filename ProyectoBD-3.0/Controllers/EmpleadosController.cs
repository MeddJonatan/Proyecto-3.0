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
    public class EmpleadosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados
                .Include(e => e.Generos)
                .Include(e => e.NumerosTelefonicos)
                .Include(e => e.Entradas)
                .Include(e => e.Salidas);
            return View(empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados
                .Include(e => e.Generos)
                .Include(e => e.NumerosTelefonicos)
                .Include(e => e.Entradas)
                .Include(e => e.Salidas)
                .FirstOrDefault(e => e.ID_Empleado == id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            PopulateDropDownLists();
            ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre");
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Empleado,NO_Empleado,Codigo_Empleado,NO_INSS,ID_DatoUsuario")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.Empleados.Any(e => e.NO_Empleado == empleados.NO_Empleado))
                    {
                        ModelState.AddModelError("NO_Empleado", "El número de empleado ya existe.");
                        PopulateDropDownLists();
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
                        return View(empleados);
                    }

                    if (db.Empleados.Any(e => e.Codigo_Empleado == empleados.Codigo_Empleado))
                    {
                        ModelState.AddModelError("Codigo_Empleado", "El código de empleado ya existe.");
                        PopulateDropDownLists();
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
                        return View(empleados);
                    }

                    var usuario = db.DatosUsuarios.Find(empleados.ID_DatoUsuario);
                    if (usuario == null)
                    {
                        ModelState.AddModelError("ID_DatoUsuario", "El usuario seleccionado no existe.");
                        PopulateDropDownLists();
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
                        return View(empleados);
                    }

                    empleados.PrimerNombre = usuario.PrimerNombre;
                    empleados.SegundoNombre = usuario.SegundoNombre;
                    empleados.PrimerApellido = usuario.PrimerApellido;
                    empleados.SegundoApellido = usuario.SegundoApellido;
                    empleados.Edad = usuario.Edad;
                    empleados.ID_NumTelefono = usuario.ID_NumTelefono;
                    empleados.ID_Genero = usuario.ID_Genero;

                    db.Empleados.Add(empleados);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el empleado: " + ex.Message);
                }
            }
            PopulateDropDownLists();
            ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados
                .Include(e => e.Generos)
                .Include(e => e.NumerosTelefonicos)
                .Include(e => e.Entradas)
                .Include(e => e.Salidas)
                .FirstOrDefault(e => e.ID_Empleado == id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownLists(empleados.ID_Genero, empleados.ID_NumTelefono);
            ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Empleado,NO_Empleado,Codigo_Empleado,NO_INSS,ID_DatoUsuario")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.Empleados.Any(e => e.NO_Empleado == empleados.NO_Empleado && e.ID_Empleado != empleados.ID_Empleado))
                    {
                        ModelState.AddModelError("NO_Empleado", "El número de empleado ya existe.");
                        PopulateDropDownLists(empleados.ID_Genero, empleados.ID_NumTelefono);
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
                        return View(empleados);
                    }

                    if (db.Empleados.Any(e => e.Codigo_Empleado == empleados.Codigo_Empleado && e.ID_Empleado != empleados.ID_Empleado))
                    {
                        ModelState.AddModelError("Codigo_Empleado", "El código de empleado ya existe.");
                        PopulateDropDownLists(empleados.ID_Genero, empleados.ID_NumTelefono);
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
                        return View(empleados);
                    }

                    var usuario = db.DatosUsuarios.Find(empleados.ID_DatoUsuario);
                    if (usuario == null)
                    {
                        ModelState.AddModelError("ID_DatoUsuario", "El usuario seleccionado no existe.");
                        PopulateDropDownLists(empleados.ID_Genero, empleados.ID_NumTelefono);
                        ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
                        return View(empleados);
                    }

                    empleados.PrimerNombre = usuario.PrimerNombre;
                    empleados.SegundoNombre = usuario.SegundoNombre;
                    empleados.PrimerApellido = usuario.PrimerApellido;
                    empleados.SegundoApellido = usuario.SegundoApellido;
                    empleados.Edad = usuario.Edad;
                    empleados.ID_NumTelefono = usuario.ID_NumTelefono;
                    empleados.ID_Genero = usuario.ID_Genero;

                    db.Entry(empleados).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al editar el empleado: " + ex.Message);
                }
            }
            PopulateDropDownLists(empleados.ID_Genero, empleados.ID_NumTelefono);
            ViewBag.DatosUsuarios = new SelectList(db.DatosUsuarios, "ID_DatoUsuario", "PrimerNombre", empleados.ID_DatoUsuario);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados
                .Include(e => e.Generos)
                .Include(e => e.NumerosTelefonicos)
                .Include(e => e.Entradas)
                .Include(e => e.Salidas)
                .FirstOrDefault(e => e.ID_Empleado == id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Empleados empleados = db.Empleados.Find(id);
                db.Empleados.Remove(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar el empleado: " + ex.Message);
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