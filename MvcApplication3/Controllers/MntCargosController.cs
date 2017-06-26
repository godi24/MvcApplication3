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
    public class MntCargosController : Controller
    {
        private bd_escuelaEntities db = new bd_escuelaEntities();

        //
        // GET: /MntCargos/

        public ActionResult Index()
        {
            return View(db.CARGO.ToList());
        }

        //
        // GET: /MntCargos/Details/5

        public ActionResult Details(int id = 0)
        {
            CARGO cargo = db.CARGO.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // GET: /MntCargos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MntCargos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CARGO cargo)
        {
            if (ModelState.IsValid)
            {
                db.CARGO.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        //
        // GET: /MntCargos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CARGO cargo = db.CARGO.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // POST: /MntCargos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CARGO cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        //
        // GET: /MntCargos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CARGO cargo = db.CARGO.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // POST: /MntCargos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARGO cargo = db.CARGO.Find(id);
            db.CARGO.Remove(cargo);
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