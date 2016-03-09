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
    public class CertifikatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Certifikat
        public ActionResult Index()
        {
            var certifikat = db.Certifikat.Include(c => c.Ponuda).Include(c => c.Potraznja);
            return View(certifikat.ToList());
        }

        // GET: Certifikat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certifikat certifikat = db.Certifikat.Find(id);
            if (certifikat == null)
            {
                return HttpNotFound();
            }
            return View(certifikat);
        }

        // GET: Certifikat/Create
        public ActionResult Create()
        {
            ViewBag.PonudaId = new SelectList(db.Ponuda, "ID", "Naziv");
            ViewBag.PotraznjaId = new SelectList(db.Potraznja, "ID", "Naziv");
            return View();
        }

        // POST: Certifikat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,PonudaId,PotraznjaId")] Certifikat certifikat)
        {
            if (ModelState.IsValid)
            {
                db.Certifikat.Add(certifikat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PonudaId = new SelectList(db.Ponuda, "ID", "Naziv", certifikat.PonudaId);
            ViewBag.PotraznjaId = new SelectList(db.Potraznja, "ID", "Naziv", certifikat.PotraznjaId);
            return View(certifikat);
        }

        // GET: Certifikat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certifikat certifikat = db.Certifikat.Find(id);
            if (certifikat == null)
            {
                return HttpNotFound();
            }
            ViewBag.PonudaId = new SelectList(db.Ponuda, "ID", "Naziv", certifikat.PonudaId);
            ViewBag.PotraznjaId = new SelectList(db.Potraznja, "ID", "Naziv", certifikat.PotraznjaId);
            return View(certifikat);
        }

        // POST: Certifikat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,PonudaId,PotraznjaId")] Certifikat certifikat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certifikat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PonudaId = new SelectList(db.Ponuda, "ID", "Naziv", certifikat.PonudaId);
            ViewBag.PotraznjaId = new SelectList(db.Potraznja, "ID", "Naziv", certifikat.PotraznjaId);
            return View(certifikat);
        }

        // GET: Certifikat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certifikat certifikat = db.Certifikat.Find(id);
            if (certifikat == null)
            {
                return HttpNotFound();
            }
            return View(certifikat);
        }

        // POST: Certifikat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certifikat certifikat = db.Certifikat.Find(id);
            db.Certifikat.Remove(certifikat);
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
