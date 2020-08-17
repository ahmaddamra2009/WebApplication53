using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication53.Models;

namespace WebApplication53.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, HttpPostedFileBase StudentImg)
        {

            if (ModelState.IsValid)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\Content\StudentsImages\" ; // Give the specific path
                if (StudentImg.ContentLength > 0)
                {
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);
                        // asdasd-asd-asd545asd35-asd654.
                        string _FileName = Guid.NewGuid().ToString() + Path.GetFileName(StudentImg.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/StudentsImages/"), _FileName);
                        StudentImg.SaveAs(_path);
                        student.StudentImg = @"~/Content/StudentsImages/" + _FileName;
                        db.Students.Add(student);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        string _FileName = Guid.NewGuid().ToString() + Path.GetFileName(StudentImg.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/StudentsImages/"), _FileName);
                        StudentImg.SaveAs(_path);
                        student.StudentImg = @"~/Content/StudentsImages/" + _FileName;
                        db.Students.Add(student);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    ViewBag.Err = "Please Select Course Image or Outline PDF ";
                    return View();
                }
            }
            else
            {
                return View(student);
            }

        }

            // GET: Students/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,City,StudentImg")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
