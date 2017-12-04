using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using plusyWeb.Models;

namespace plusyWeb.Controllers
{
    public class ZadaniaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zadania
        public ActionResult Index()
        {
            return View(db.Zadania.ToList());
        }

        // GET: Zadania/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadanie zadanie = db.Zadania.Find(id);
            if (zadanie == null)
            {
                return HttpNotFound();
            }
            return View(zadanie);
        }

        // GET: Zadania/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zadania/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa")] Zadanie zadanie)
        {
            if (ModelState.IsValid)
            {
                db.Zadania.Add(zadanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zadanie);
        }

        // GET: Zadania/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadanie zadanie = db.Zadania.Find(id);
            if (zadanie == null)
            {
                return HttpNotFound();
            }
            return View(zadanie);
        }

        // POST: Zadania/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa")] Zadanie zadanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zadanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zadanie);
        }

        // GET: Zadania/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadanie zadanie = db.Zadania.Find(id);
            if (zadanie == null)
            {
                return HttpNotFound();
            }
            return View(zadanie);
        }

        // POST: Zadania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zadanie zadanie = db.Zadania.Find(id);
            db.Zadania.Remove(zadanie);
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
