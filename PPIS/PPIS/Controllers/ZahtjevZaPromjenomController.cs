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
    public class ZahtjevZaPromjenomController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ZahtjevZaPromjenom
        [Authorize(Roles = "Cab,ChangeManager")]
        public ActionResult Index()
        {
         
            List<ZahtjevZaPromjenom> zahtjevi = db.ZahtjevZaPromjenom.ToList();

            if (User.IsInRole("Cab")) zahtjevi = db.ZahtjevZaPromjenom.Where(z => z.StatusZahtjevaZaPromjenom == StatusZahtjevaZaPromjenom.Cab).ToList();

            return View(zahtjevi);
        }

        // GET: ZahtjevZaPromjenom/Details/5ž
        [Authorize(Roles = "Cab,ChangeManager")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahtjevZaPromjenom zahtjevZaPromjenom = db.ZahtjevZaPromjenom.Find(id);
            if (zahtjevZaPromjenom == null)
            {
                return HttpNotFound();
            }
            return View(zahtjevZaPromjenom);
        }

        // GET: ZahtjevZaPromjenom/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZahtjevZaPromjenom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public ActionResult Create(ZahtjevZaPromjenom zahtjevZaPromjenom)
        {
            if (ModelState.IsValid)
            {
                zahtjevZaPromjenom.UserId = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                zahtjevZaPromjenom.DatumPodnosenja = DateTime.Now;
                db.ZahtjevZaPromjenom.Add(zahtjevZaPromjenom);                       
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                   
                 
            return View(zahtjevZaPromjenom);
        }

        // GET: ZahtjevZaPromjenom/Edit/5
        [Authorize(Roles = "Cab,ChangeManager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahtjevZaPromjenom zahtjevZaPromjenom = db.ZahtjevZaPromjenom.Find(id);
            if (zahtjevZaPromjenom == null)
            {
                return HttpNotFound();
            }
            return View(zahtjevZaPromjenom);
        }

        // POST: ZahtjevZaPromjenom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cab,ChangeManager")]
        public ActionResult Edit(ZahtjevZaPromjenom zahtjevZaPromjenom)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Cab")) zahtjevZaPromjenom.CabId = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                if (User.IsInRole("UserManager")) zahtjevZaPromjenom.MenadzerId = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                db.Entry(zahtjevZaPromjenom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zahtjevZaPromjenom);
        }

        // GET: ZahtjevZaPromjenom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahtjevZaPromjenom zahtjevZaPromjenom = db.ZahtjevZaPromjenom.Find(id);
            if (zahtjevZaPromjenom == null)
            {
                return HttpNotFound();
            }
            return View(zahtjevZaPromjenom);
        }

        // POST: ZahtjevZaPromjenom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZahtjevZaPromjenom zahtjevZaPromjenom = db.ZahtjevZaPromjenom.Find(id);
            db.ZahtjevZaPromjenom.Remove(zahtjevZaPromjenom);
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
