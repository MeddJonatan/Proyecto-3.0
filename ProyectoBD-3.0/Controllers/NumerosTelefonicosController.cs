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
    public class NumerosTelefonicosController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // Método privado para obtener la lista de empresas telefónicas
        private IEnumerable<SelectListItem> GetTelefonicaList()
        {
            return db.EmpresasTelefonicas.Select(e => new SelectListItem
            {
                Value = e.ID_EmpresaTelefonica.ToString(),
                Text = e.Nombre_EmpresaTelefonica
            }).ToList();
        }

        // GET: NumerosTelefonicos
        public ActionResult Index()
        {
            return View(db.NumerosTelefonicos.ToList());
        }

        // GET: NumerosTelefonicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerosTelefonicos numerosTelefonicos = db.NumerosTelefonicos.Find(id);
            if (numerosTelefonicos == null)
            {
                return HttpNotFound();
            }
            return View(numerosTelefonicos);
        }

        // GET: NumerosTelefonicos/Create
        public ActionResult Create()
        {
            ViewData["ID_EmpresaTelefonica"] = GetTelefonicaList();
            return View();
        }

        // POST: NumerosTelefonicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NumTelefono,NumeroTelefono,ID_EmpresaTelefonica")] NumerosTelefonicos numerosTelefonicos)
        {
            if (ModelState.IsValid)
            {
                db.NumerosTelefonicos.Add(numerosTelefonicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["ID_EmpresaTelefonica"] = GetTelefonicaList();
            return View(numerosTelefonicos);
        }

        // GET: NumerosTelefonicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerosTelefonicos numerosTelefonicos = db.NumerosTelefonicos.Find(id);
            if (numerosTelefonicos == null)
            {
                return HttpNotFound();
            }
            ViewData["ID_EmpresaTelefonica"] = GetTelefonicaList();
            return View(numerosTelefonicos);
        }

        // POST: NumerosTelefonicos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NumTelefono,NumeroTelefono,ID_EmpresaTelefonica")] NumerosTelefonicos numerosTelefonicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numerosTelefonicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ID_EmpresaTelefonica"] = GetTelefonicaList();
            return View(numerosTelefonicos);
        }

        // GET: NumerosTelefonicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerosTelefonicos numerosTelefonicos = db.NumerosTelefonicos.Find(id);
            if (numerosTelefonicos == null)
            {
                return HttpNotFound();
            }
            return View(numerosTelefonicos);
        }

        // POST: NumerosTelefonicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            NumerosTelefonicos numerosTelefonicos = db.NumerosTelefonicos.Find(id);
            db.NumerosTelefonicos.Remove(numerosTelefonicos);
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
