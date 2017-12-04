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
    public class BohaterowieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bohaterowie
        public ActionResult Index()
        {
            var bohaterowie = db.Bohaterowie.Include(b => b.WojewodztwoBohatera);
            return View(bohaterowie.ToList());
        }

        // GET: Bohaterowie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bohater bohater = db.Bohaterowie.Find(id);
            if (bohater == null)
            {
                return HttpNotFound();
            }
            return View(bohater);
        }

        // GET: Bohaterowie/Create
        public ActionResult Create()
        {
            ViewBag.WojewodztwoId = new SelectList(db.Wojewodztwa, "Id", "Nazwa");
            return View();
        }

        // POST: Bohaterowie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imie,WojewodztwoId,RokUrodzenia")] Bohater bohater)
        {
            if (ModelState.IsValid)
            {
                db.Bohaterowie.Add(bohater);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WojewodztwoId = new SelectList(db.Wojewodztwa, "Id", "Nazwa", bohater.WojewodztwoId);
            return View(bohater);
        }

        // GET: Bohaterowie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bohater bohater = db.Bohaterowie.Find(id);
            if (bohater == null)
            {
                return HttpNotFound();
            }
            ViewBag.WojewodztwoId = new SelectList(db.Wojewodztwa, "Id", "Nazwa", bohater.WojewodztwoId);
            return View(bohater);
        }

        // POST: Bohaterowie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Imie,WojewodztwoId,RokUrodzenia")] Bohater bohater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bohater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WojewodztwoId = new SelectList(db.Wojewodztwa, "Id", "Nazwa", bohater.WojewodztwoId);
            return View(bohater);
        }

        // GET: Bohaterowie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bohater bohater = db.Bohaterowie.Find(id);
            if (bohater == null)
            {
                return HttpNotFound();
            }
            return View(bohater);
        }

        // POST: Bohaterowie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bohater bohater = db.Bohaterowie.Find(id);
            db.Bohaterowie.Remove(bohater);
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
