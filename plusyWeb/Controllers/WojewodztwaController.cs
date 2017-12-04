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
    public class WojewodztwaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wojewodztwa
        public ActionResult Index()
        {
            return View(db.Wojewodztwa.ToList());
        }

        // GET: Wojewodztwa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwa.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // GET: Wojewodztwa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wojewodztwa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa")] Wojewodztwo wojewodztwo)
        {
            if (ModelState.IsValid)
            {
                db.Wojewodztwa.Add(wojewodztwo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wojewodztwo);
        }

        // GET: Wojewodztwa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwa.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // POST: Wojewodztwa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa")] Wojewodztwo wojewodztwo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wojewodztwo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wojewodztwo);
        }

        // GET: Wojewodztwa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwa.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // POST: Wojewodztwa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wojewodztwo wojewodztwo = db.Wojewodztwa.Find(id);
            db.Wojewodztwa.Remove(wojewodztwo);
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
