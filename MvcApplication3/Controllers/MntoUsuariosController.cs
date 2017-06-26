using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;

namespace MvcApplication3.Controllers
{
    public class MntoUsuariosController : Controller
    {
        private bd_escuelaEntities db = new bd_escuelaEntities();

        //
        // GET: /MntoUsuarios/

        public ActionResult Index()
        {
            var usuario = db.USUARIO.Include(u => u.CARGO);
            return View(usuario.ToList());
        }

        //
        // GET: /MntoUsuarios/Details/5

        public ActionResult Details(int id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /MntoUsuarios/Create

        public ActionResult Create()
        {
            ViewBag.codigo_cargo = new SelectList(db.CARGO, "codigo_cargo", "descripcion");
            return View();
        }

        //
        // POST: /MntoUsuarios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_cargo = new SelectList(db.CARGO, "codigo_cargo", "descripcion", usuario.codigo_cargo);
            return View(usuario);
        }

        //
        // GET: /MntoUsuarios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_cargo = new SelectList(db.CARGO, "codigo_cargo", "descripcion", usuario.codigo_cargo);
            return View(usuario);
        }

        //
        // POST: /MntoUsuarios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_cargo = new SelectList(db.CARGO, "codigo_cargo", "descripcion", usuario.codigo_cargo);
            return View(usuario);
        }

        //
        // GET: /MntoUsuarios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /MntoUsuarios/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            db.USUARIO.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}