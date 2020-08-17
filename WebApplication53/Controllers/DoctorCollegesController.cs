using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication53.Models;

namespace WebApplication53.Controllers
{
    public class DoctorCollegesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DoctorColleges
        public ActionResult Index()
        {
            var doctorColleges = db.DoctorColleges.Include(d => d.College).Include(d => d.Doctor);
            return View(doctorColleges.ToList());
        }

        // GET: DoctorColleges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorColleges doctorColleges = db.DoctorColleges.Find(id);
            if (doctorColleges == null)
            {
                return HttpNotFound();
            }
            return View(doctorColleges);
        }

        // GET: DoctorColleges/Create
        public ActionResult Create()
        {
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            return View();
        }

        // POST: DoctorColleges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,CollegeId")] DoctorColleges doctorColleges)
        {
            if (ModelState.IsValid)
            {
                db.DoctorColleges.Add(doctorColleges);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", doctorColleges.CollegeId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", doctorColleges.DoctorId);
            return View(doctorColleges);
        }

        // GET: DoctorColleges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorColleges doctorColleges = db.DoctorColleges.Find(id);
            if (doctorColleges == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", doctorColleges.CollegeId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", doctorColleges.DoctorId);
            return View(doctorColleges);
        }

        // POST: DoctorColleges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,CollegeId")] DoctorColleges doctorColleges)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorColleges).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollegeId = new SelectList(db.Colleges, "CollegeId", "CollegeName", doctorColleges.CollegeId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", doctorColleges.DoctorId);
            return View(doctorColleges);
        }

        // GET: DoctorColleges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorColleges doctorColleges = db.DoctorColleges.Find(id);
            if (doctorColleges == null)
            {
                return HttpNotFound();
            }
            return View(doctorColleges);
        }

        // POST: DoctorColleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorColleges doctorColleges = db.DoctorColleges.Find(id);
            db.DoctorColleges.Remove(doctorColleges);
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
