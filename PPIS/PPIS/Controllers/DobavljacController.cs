using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPIS.Models;

namespace PPIS.Controllers
{
    public class DobavljacController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dobavljac
        public ActionResult Index()
        {
            return View(db.Dobavljac.ToList());
        }

        // GET: Dobavljac/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dobavljac dobavljac = db.Dobavljac.Find(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // GET: Dobavljac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dobavljac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Adresa,Telefon,Email")] Dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                db.Dobavljac.Add(dobavljac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dobavljac);
        }

        // GET: Dobavljac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dobavljac dobavljac = db.Dobavljac.Find(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // POST: Dobavljac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Adresa,Telefon,Email")] Dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dobavljac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dobavljac);
        }

        // GET: Dobavljac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dobavljac dobavljac = db.Dobavljac.Find(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // POST: Dobavljac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dobavljac dobavljac = db.Dobavljac.Find(id);
            db.Dobavljac.Remove(dobavljac);
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
