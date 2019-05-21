using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkoutAnalytics.UI.DAL;
using WorkoutAnalytics.UI.Models;

namespace WorkoutAnalytics.UI.Controllers
{
    public class UserWorkoutTemplatesController : Controller
    {
        private WorkoutContext db = new WorkoutContext();

        // GET: UserWorkoutTemplates
        public ActionResult Index()
        {
            var userWorkoutTemplates = db.UserWorkoutTemplates.Include(u => u.UserTemplate).Include(u => u.Workout);
            return View(userWorkoutTemplates.ToList());
        }

        // GET: UserWorkoutTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkoutTemplate userWorkoutTemplate = db.UserWorkoutTemplates.Find(id);
            if (userWorkoutTemplate == null)
            {
                return HttpNotFound();
            }
            return View(userWorkoutTemplate);
        }

        // GET: UserWorkoutTemplates/Create
        public ActionResult Create()
        {
            ViewBag.TemplateID = new SelectList(db.UserTemplates, "TemplateID", "TemplateDesc");
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "WorkoutBodyArea");
            return View();
        }

        // POST: UserWorkoutTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TemplateID,WorkoutID,WorkoutDesc")] UserWorkoutTemplate userWorkoutTemplate)
        {
            if (ModelState.IsValid)
            {
                db.UserWorkoutTemplates.Add(userWorkoutTemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TemplateID = new SelectList(db.UserTemplates, "TemplateID", "TemplateDesc", userWorkoutTemplate.TemplateID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "WorkoutBodyArea", userWorkoutTemplate.WorkoutID);
            return View(userWorkoutTemplate);
        }

        // GET: UserWorkoutTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkoutTemplate userWorkoutTemplate = db.UserWorkoutTemplates.Find(id);
            if (userWorkoutTemplate == null)
            {
                return HttpNotFound();
            }
            ViewBag.TemplateID = new SelectList(db.UserTemplates, "TemplateID", "TemplateDesc", userWorkoutTemplate.TemplateID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "WorkoutBodyArea", userWorkoutTemplate.WorkoutID);
            return View(userWorkoutTemplate);
        }

        // POST: UserWorkoutTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TemplateID,WorkoutID,WorkoutDesc")] UserWorkoutTemplate userWorkoutTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userWorkoutTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TemplateID = new SelectList(db.UserTemplates, "TemplateID", "TemplateDesc", userWorkoutTemplate.TemplateID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "WorkoutBodyArea", userWorkoutTemplate.WorkoutID);
            return View(userWorkoutTemplate);
        }

        // GET: UserWorkoutTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkoutTemplate userWorkoutTemplate = db.UserWorkoutTemplates.Find(id);
            if (userWorkoutTemplate == null)
            {
                return HttpNotFound();
            }
            return View(userWorkoutTemplate);
        }

        // POST: UserWorkoutTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserWorkoutTemplate userWorkoutTemplate = db.UserWorkoutTemplates.Find(id);
            db.UserWorkoutTemplates.Remove(userWorkoutTemplate);
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
