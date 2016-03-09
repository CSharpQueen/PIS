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
    public class PotraznjaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Potraznja
        public ActionResult Index()
        {
            var potraznja = db.Potraznja.Include(p => p.OcjenaDobavljaca).Include(p => p.Ponuda);
            return View(potraznja.ToList());
        }

        // GET: Potraznja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potraznja potraznja = db.Potraznja.Find(id);
            if (potraznja == null)
            {
                return HttpNotFound();
            }
            return View(potraznja);
        }

        // GET: Potraznja/Create
        public ActionResult Create()
        {
            ViewBag.OcjenaDobavljacaId = new SelectList(db.OcjenaDobavljaca, "ID", "ID");
            ViewBag.PonudaId = new SelectList(db.Ponuda, "ID", "Naziv");
            return View();
        }

        // POST: Potraznja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,Cijena,PrioritetCijene,Opis,RokIsporuke,PrioritetRokaIsporuke,PonudaId,OcjenaDobavljacaId")] Potraznja potraznja)
        {
            if (ModelState.IsValid)
            {
                db.Potraznja.Add(potraznja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OcjenaDobavljacaId = new SelectList(db.OcjenaDobavljaca, "ID", "ID", potraznja.OcjenaDobavljacaId);
            ViewBag.PonudaId = new SelectList(db.Ponuda, "ID", "Naziv", potraznja.PonudaId);
            return View(potraznja);
        }

        // GET: Potraznja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potraznja potraznja = db.Potraznja.Find(id);
            if (potraznja == null)
            {
                return HttpNotFound();
            }
            ViewBag.OcjenaDobavljacaId = new SelectList(db.OcjenaDobavljaca, "ID", "ID", potraznja.OcjenaDobavljacaId);
            ViewBag.PonudaId = new SelectList(db.Ponuda, "ID", "Naziv", potraznja.PonudaId);
            return View(potraznja);
        }

        // POST: Potraznja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Cijena,PrioritetCijene,Opis,RokIsporuke,PrioritetRokaIsporuke,PonudaId,OcjenaDobavljacaId")] Potraznja potraznja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potraznja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OcjenaDobavljacaId = new SelectList(db.OcjenaDobavljaca, "ID", "ID", potraznja.OcjenaDobavljacaId);
            ViewBag.PonudaId = new SelectList(db.Ponuda, "ID", "Naziv", potraznja.PonudaId);
            return View(potraznja);
        }

        // GET: Potraznja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potraznja potraznja = db.Potraznja.Find(id);
            if (potraznja == null)
            {
                return HttpNotFound();
            }
            return View(potraznja);
        }

        // POST: Potraznja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Potraznja potraznja = db.Potraznja.Find(id);
            db.Potraznja.Remove(potraznja);
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
