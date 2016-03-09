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
    public class UgovorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ugovor
        public ActionResult Index()
        {
            var ugovor = db.Ugovor.Include(u => u.Dobavljac);
            return View(ugovor.ToList());
        }

        // GET: Ugovor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugovor ugovor = db.Ugovor.Find(id);
            if (ugovor == null)
            {
                return HttpNotFound();
            }
            return View(ugovor);
        }

        // GET: Ugovor/Create
        public ActionResult Create()
        {
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv");
            return View();
        }

        // POST: Ugovor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PeriodVazenjaOd,PeriodVazenjaDo,sadrzajUgovora,potpisnikUgovoraSupplier,potpisnikUgovoraManager,dodatneStavke,DobavljacId")] Ugovor ugovor)
        {
            if (ModelState.IsValid)
            {
                db.Ugovor.Add(ugovor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ugovor.DobavljacId);
            return View(ugovor);
        }

        // GET: Ugovor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugovor ugovor = db.Ugovor.Find(id);
            if (ugovor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ugovor.DobavljacId);
            return View(ugovor);
        }

        // POST: Ugovor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PeriodVazenjaOd,PeriodVazenjaDo,sadrzajUgovora,potpisnikUgovoraSupplier,potpisnikUgovoraManager,dodatneStavke,DobavljacId")] Ugovor ugovor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ugovor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ugovor.DobavljacId);
            return View(ugovor);
        }

        // GET: Ugovor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugovor ugovor = db.Ugovor.Find(id);
            if (ugovor == null)
            {
                return HttpNotFound();
            }
            return View(ugovor);
        }

        // POST: Ugovor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ugovor ugovor = db.Ugovor.Find(id);
            db.Ugovor.Remove(ugovor);
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
