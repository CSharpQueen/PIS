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
    public class PonudaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ponuda
        public ActionResult Index()
        {
            var ponuda = db.Ponuda.Include(p => p.Dobavljac);
            return View(ponuda.ToList());
        }

        // GET: Ponuda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponuda ponuda = db.Ponuda.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            return View(ponuda);
        }

        // GET: Ponuda/Create
        public ActionResult Create()
        {
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv");
            return View();
        }

        // POST: Ponuda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,Cijena,Opis,RokIsporuke,DobavljacId")] Ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                db.Ponuda.Add(ponuda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ponuda.DobavljacId);
            return View(ponuda);
        }

        // GET: Ponuda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponuda ponuda = db.Ponuda.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ponuda.DobavljacId);
            return View(ponuda);
        }

        // POST: Ponuda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Cijena,Opis,RokIsporuke,DobavljacId")] Ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponuda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ponuda.DobavljacId);
            return View(ponuda);
        }

        // GET: Ponuda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponuda ponuda = db.Ponuda.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            return View(ponuda);
        }

        // POST: Ponuda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ponuda ponuda = db.Ponuda.Find(id);
            db.Ponuda.Remove(ponuda);
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
