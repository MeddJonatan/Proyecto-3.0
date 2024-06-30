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
    public class EmpresasTelefonicasController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: EmpresasTelefonicas
        public ActionResult Index()
        {
            return View(db.EmpresasTelefonicas.ToList());
        }

        // GET: EmpresasTelefonicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresasTelefonicas empresasTelefonicas = db.EmpresasTelefonicas.Find(id);
            if (empresasTelefonicas == null)
            {
                return HttpNotFound();
            }
            return View(empresasTelefonicas);
        }

        // GET: EmpresasTelefonicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresasTelefonicas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EmpresaTelefonica,Nombre_EmpresaTelefonica")] EmpresasTelefonicas empresasTelefonicas)
        {
            if (ModelState.IsValid)
            {
                db.EmpresasTelefonicas.Add(empresasTelefonicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresasTelefonicas);
        }

        // GET: EmpresasTelefonicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresasTelefonicas empresasTelefonicas = db.EmpresasTelefonicas.Find(id);
            if (empresasTelefonicas == null)
            {
                return HttpNotFound();
            }
            return View(empresasTelefonicas);
        }

        // POST: EmpresasTelefonicas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EmpresaTelefonica,Nombre_EmpresaTelefonica")] EmpresasTelefonicas empresasTelefonicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresasTelefonicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresasTelefonicas);
        }

        // GET: EmpresasTelefonicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresasTelefonicas empresasTelefonicas = db.EmpresasTelefonicas.Find(id);
            if (empresasTelefonicas == null)
            {
                return HttpNotFound();
            }
            return View(empresasTelefonicas);
        }

        // POST: EmpresasTelefonicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            EmpresasTelefonicas empresasTelefonicas = db.EmpresasTelefonicas.Find(id);
            db.EmpresasTelefonicas.Remove(empresasTelefonicas);
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