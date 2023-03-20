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
    public class PetOwnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PetOwners
       // [Authorize]
        [Authorize(Roles = "Admin")]

        public ActionResult Index()
        {
            return View(db.PetOwners.ToList());
        }

        // GET: PetOwners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetOwner petOwner = db.PetOwners.Find(id);
            if (petOwner == null)
            {
                return HttpNotFound();
            }
            return View(petOwner);
        }

        // GET: PetOwners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PetOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "onwer_id,OwnerName,Surname,Phone_number,Email_address,Postal_Address,ID_Number,AccountNumber")] PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                db.PetOwners.Add(petOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(petOwner);
        }

        // GET: PetOwners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetOwner petOwner = db.PetOwners.Find(id);
            if (petOwner == null)
            {
                return HttpNotFound();
            }
            return View(petOwner);
        }

        // POST: PetOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "onwer_id,OwnerName,Surname,Phone_number,Email_address,Postal_Address,ID_Number,AccountNumber")] PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petOwner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(petOwner);
        }

        // GET: PetOwners/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetOwner petOwner = db.PetOwners.Find(id);
            if (petOwner == null)
            {
                return HttpNotFound();
            }
            return View(petOwner);
        }

        // POST: PetOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetOwner petOwner = db.PetOwners.Find(id);
            db.PetOwners.Remove(petOwner);
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
