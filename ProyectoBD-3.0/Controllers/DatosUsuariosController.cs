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
    public class DatosUsuariosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: DatosUsuarios
        public ActionResult Index()
        {
            var datosUsuarios = db.DatosUsuarios.Include(d => d.Generos).Include(d => d.NumerosTelefonicos);
            return View(datosUsuarios.ToList());
        }

        // GET: DatosUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosUsuarios datosUsuarios = db.DatosUsuarios.Include(d => d.Generos).Include(d => d.NumerosTelefonicos).FirstOrDefault(d => d.ID_DatoUsuario == id);
            if (datosUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(datosUsuarios);
        }

        // GET: DatosUsuarios/Create
        public ActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        //// POST: DatosUsuarios/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID_DatoUsuario,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Edad,ID_NumTelefono,ID_Genero")] DatosUsuarios datosUsuarios)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.DatosUsuarios.Add(datosUsuarios);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    PopulateDropDownLists(datosUsuarios.ID_Genero, datosUsuarios.ID_NumTelefono);
        //    return View(datosUsuarios);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DatoUsuario,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Edad,ID_NumTelefono,ID_Genero")] DatosUsuarios datosUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.DatosUsuarios.Add(datosUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Agregar depuración para errores de validación
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            PopulateDropDownLists(datosUsuarios.ID_Genero, datosUsuarios.ID_NumTelefono);
            return View(datosUsuarios);
        }

        // GET: DatosUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosUsuarios datosUsuarios = db.DatosUsuarios.Include(d => d.Generos).Include(d => d.NumerosTelefonicos).FirstOrDefault(d => d.ID_DatoUsuario == id);
            if (datosUsuarios == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownLists(datosUsuarios.ID_Genero, datosUsuarios.ID_NumTelefono);
            return View(datosUsuarios);
        }

        // POST: DatosUsuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DatoUsuario,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Edad,ID_NumTelefono,ID_Genero")] DatosUsuarios datosUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropDownLists(datosUsuarios.ID_Genero, datosUsuarios.ID_NumTelefono);
            return View(datosUsuarios);
        }

        // Helper method to set ViewBag for dropdowns
        private void PopulateDropDownLists(int? selectedGender = null, int? selectedPhone = null)
        {
            ViewBag.ID_Genero = new SelectList(db.Generos, "ID_Genero", "Descripcion_Genero", selectedGender);
            ViewBag.ID_NumTelefono = new SelectList(db.NumerosTelefonicos, "ID_NumTelefono", "NumeroTelefono", selectedPhone);
        }

        // GET: DatosUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosUsuarios datosUsuarios = db.DatosUsuarios.Include(d => d.Generos).Include(d => d.NumerosTelefonicos).FirstOrDefault(d => d.ID_DatoUsuario == id);
            if (datosUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(datosUsuarios);
        }

        // POST: DatosUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DatosUsuarios datosUsuarios = db.DatosUsuarios.Find(id);
            db.DatosUsuarios.Remove(datosUsuarios);
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
