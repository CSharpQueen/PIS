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
    public class OcjenaDobavljacaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OcjenaDobavljaca
        public ActionResult Index()
        {
            var ocjenaDobavljaca = db.OcjenaDobavljaca.Include(o => o.Dobavljac);
            return View(ocjenaDobavljaca.ToList());
        }

        // GET: OcjenaDobavljaca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OcjenaDobavljaca ocjenaDobavljaca = db.OcjenaDobavljaca.Find(id);
            if (ocjenaDobavljaca == null)
            {
                return HttpNotFound();
            }
            return View(ocjenaDobavljaca);
        }

        // GET: OcjenaDobavljaca/Create
        public ActionResult Create()
        {
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv");
            return View();
        }

        // POST: OcjenaDobavljaca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DobavljacId,OcjenaCijene,OcjenaRokaIporuke,IspostovaneStavkeUgovora,KvalitetIsporuke,Utisak")] OcjenaDobavljaca ocjenaDobavljaca)
        {
            int ocjena = ocjenaDobavljaca.OcjenaCijene + ocjenaDobavljaca.OcjenaRokaIporuke + ocjenaDobavljaca.IspostovaneStavkeUgovora + ocjenaDobavljaca.KvalitetIsporuke + ocjenaDobavljaca.Utisak;
            ocjenaDobavljaca.Ocjena = ocjena;

            if (ocjena >= 35)
                ocjenaDobavljaca.OpisnaOcjena = "visoka";
            else if (ocjena < 35 && ocjena > 20)
                ocjenaDobavljaca.OpisnaOcjena = "srednja";
            else if (ocjena < 20)
                ocjenaDobavljaca.OpisnaOcjena = "niska";

            if (ModelState.IsValid)
            {
                db.OcjenaDobavljaca.Add(ocjenaDobavljaca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ocjenaDobavljaca.DobavljacId);
            return View(ocjenaDobavljaca);
        }

        // GET: OcjenaDobavljaca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OcjenaDobavljaca ocjenaDobavljaca = db.OcjenaDobavljaca.Find(id);
            if (ocjenaDobavljaca == null)
            {
                return HttpNotFound();
            }
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ocjenaDobavljaca.DobavljacId);
            return View(ocjenaDobavljaca);
        }

        // POST: OcjenaDobavljaca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DobavljacId,OcjenaCijene,OcjenaRokaIporuke,IspostovaneStavkeUgovora,KvalitetIsporuke,Utisak,Ocjena,OpisnaOcjena")] OcjenaDobavljaca ocjenaDobavljaca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocjenaDobavljaca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DobavljacId = new SelectList(db.Dobavljac, "Id", "Naziv", ocjenaDobavljaca.DobavljacId);
            return View(ocjenaDobavljaca);
        }

        // GET: OcjenaDobavljaca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OcjenaDobavljaca ocjenaDobavljaca = db.OcjenaDobavljaca.Find(id);
            if (ocjenaDobavljaca == null)
            {
                return HttpNotFound();
            }
            return View(ocjenaDobavljaca);
        }

        // POST: OcjenaDobavljaca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OcjenaDobavljaca ocjenaDobavljaca = db.OcjenaDobavljaca.Find(id);
            db.OcjenaDobavljaca.Remove(ocjenaDobavljaca);
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
