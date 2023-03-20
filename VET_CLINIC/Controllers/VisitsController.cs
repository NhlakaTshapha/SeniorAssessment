using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VET_CLINIC.Models;

namespace VET_CLINIC.Controllers
{
    public class VisitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Visits
        [Authorize]
        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Pet).Include(v => v.Vet);
            return View(visits.ToList());
        }

        // GET: Visits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: Visits/Create
        public ActionResult Create()
        {
            ViewBag.pet_id = new SelectList(db.Pets, "pet_id", "Name");
            ViewBag.VetID = new SelectList(db.Vets, "VetID", "VetName");
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitID,pet_id,VetID,VisitDate")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                visit.VisitDate = DateTime.Now;
                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pet_id = new SelectList(db.Pets, "pet_id", "Name", visit.pet_id);
            ViewBag.VetID = new SelectList(db.Vets, "VetID", "VetName", visit.VetID);
            return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.pet_id = new SelectList(db.Pets, "pet_id", "Name", visit.pet_id);
            ViewBag.VetID = new SelectList(db.Vets, "VetID", "VetName", visit.VetID);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitID,pet_id,VetID,VisitDate")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pet_id = new SelectList(db.Pets, "pet_id", "Name", visit.pet_id);
            ViewBag.VetID = new SelectList(db.Vets, "VetID", "VetName", visit.VetID);
            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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
