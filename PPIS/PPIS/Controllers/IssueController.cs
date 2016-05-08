using PPIS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PPIS.Controllers
{
    public class IssueController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ZahtjevZaPromjenom
      //  [Authorize(Roles = "User,Incident,Event,ProblemManager")]
        public ActionResult Index()
        {
           // return View();
             List<Issue> issue = db.Issue.ToList();

             //if (User.IsInRole("Cab")) zahtjevi = db.ZahtjevZaPromjenom.Where(z => z.StatusZahtjevaZaPromjenom == StatusZahtjevaZaPromjenom.Cab).ToList();
             //z.UserId == db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id)).ToList();
             if (User.IsInRole("User")) issue = db.Issue.Where(z => z.StatusProblema == StatusProblema.Poslan || z.StatusProblema == StatusProblema.PonovoOtvoren || z.StatusProblema == StatusProblema.Riješen || z.StatusProblema == StatusProblema.Odbijen).OrderByDescending(z => z.PrioritetProblema).ToList();
             if (User.IsInRole("Incident")) issue = db.Issue.OrderBy(z => z.PrioritetProblema).ToList();
             if (User.IsInRole("Event")) issue = db.Issue.Where(z => (z.StatusProblema == StatusProblema.Incident || z.StatusProblema == StatusProblema.Riješen)).OrderByDescending(z => z.PrioritetProblema).ToList();
            if (User.IsInRole("Problem")) issue = db.Issue.Where(z => (z.StatusProblema == StatusProblema.Problem )).OrderByDescending(z => z.PrioritetProblema).ToList();

            return View(issue);
         }

         // GET: ZahtjevZaPromjenom/Details/5
         [Authorize(Roles = "User,Event,Incident,ProblemManager")]
         public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Issue issue = db.Issue.Find(id);
             if (issue == null)
             {
                 return HttpNotFound();
             }
             return View(issue);
         }

         // GET: ZahtjevZaPromjenom/Create
         [Authorize(Roles = "User,Event,Incident,ProblemManager")]
         public ActionResult Create()
         {
             return View();
         }

         // POST: ZahtjevZaPromjenom/Create
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         [Authorize(Roles = "User,Event,Incident,ProblemManager")]
         public ActionResult Create(Issue issue)
         {
             if (ModelState.IsValid)
             {
                 issue.UserId = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                issue.DatumPodnosenja = DateTime.Now;
                issue.StatusProblema = StatusProblema.Poslan;
                issue.PrioritetProblema = PrioritetProblema.nizak;
                 db.Issue.Add(issue);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }


             return View(issue);
         }

         // GET: ZahtjevZaPromjenom/Edit/5
         [Authorize(Roles = "User,Event,Incident,ProblemManager")]
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Issue issue= db.Issue.Find(id);
             if (issue == null)
             {
                 return HttpNotFound();
             }
            ViewBag.Problems = db.Problems.ToList();
             return View(issue);
         }

         // POST: ZahtjevZaPromjenom/Edit/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         [Authorize(Roles = "User,Incident,Event,ProblemManager")]
         public ActionResult Edit(Issue issue)
         {
             if (ModelState.IsValid)
             {
                 if (User.IsInRole("User")) issue.UserId = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                 if (User.IsInRole("Incident")) issue.IncidentId = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                if (User.IsInRole("Event")) issue.EventId = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                if (User.IsInRole("ProblemManager")) issue.ProblemManagerId = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;

                db.Entry(issue).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             return View(issue);
         }

         // GET: ZahtjevZaPromjenom/Delete/5
         [Authorize(Roles = "ProblemManager")]
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Issue issue = db.Issue.Find(id);
             if (issue == null)
             {
                 return HttpNotFound();
             }
             return View(issue);
         }

         // POST: ZahtjevZaPromjenom/Delete/5
         [Authorize(Roles = "ProblemManager")]
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             Issue issue = db.Issue.Find(id);
             db.Issue.Remove(issue);
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
