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
    public class PetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pets
        [Authorize]
        public ActionResult Index()
        {
            var pets = db.Pets.Include(p => p.AnimalType).Include(p => p.PetOwner);
            return View(pets.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.AnimalTypeID = new SelectList(db.AnimalTypes, "AnimalTypeID", "Name");
            ViewBag.onwer_id = new SelectList(db.PetOwners, "onwer_id", "OwnerName");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pet_id,Name,AnimalTypeID,Breed,onwer_id,Birthdate")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalTypeID = new SelectList(db.AnimalTypes, "AnimalTypeID", "Name", pet.AnimalTypeID);
            ViewBag.onwer_id = new SelectList(db.PetOwners, "onwer_id", "OwnerName", pet.onwer_id);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalTypeID = new SelectList(db.AnimalTypes, "AnimalTypeID", "Name", pet.AnimalTypeID);
            ViewBag.onwer_id = new SelectList(db.PetOwners, "onwer_id", "OwnerName", pet.onwer_id);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pet_id,Name,AnimalTypeID,Breed,onwer_id,Birthdate")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalTypeID = new SelectList(db.AnimalTypes, "AnimalTypeID", "Name", pet.AnimalTypeID);
            ViewBag.onwer_id = new SelectList(db.PetOwners, "onwer_id", "OwnerName", pet.onwer_id);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
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
