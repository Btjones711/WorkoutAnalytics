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
    public class WorkoutsController : Controller
    {
        private WorkoutContext db = new WorkoutContext();

        // GET: Workouts
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.WorkoutDescParam = String.IsNullOrEmpty(sortOrder) ? "WorkoutDesc_desc" : "";
            ViewBag.WorkoutBodyAreaParam = sortOrder == "BodyArea" ? "BodyArea_desc" : "BodyArea";
            var workouts = from w in db.Workouts select w;
            if (!String.IsNullOrEmpty(searchString))
            {
                workouts = workouts.Where(w => w.WorkoutDesc.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "WorkoutDesc_desc":
                    workouts = workouts.OrderByDescending(w => w.WorkoutDesc);
                    break;
                case "BodyArea_desc":
                    workouts = workouts.OrderByDescending(w => w.WorkoutBodyArea);
                    break;
                case "BodyArea":
                    workouts = workouts.OrderBy(w => w.WorkoutBodyArea);
                    break;
                default:
                    workouts = workouts.OrderBy(w => w.WorkoutDesc);
                    break;
            }
            return View(workouts.ToList());
        }

        // GET: Workouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // GET: Workouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkoutID,WorkoutDesc,WorkoutBodyArea")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workout);
        }

        // GET: Workouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkoutID,WorkoutDesc,WorkoutBodyArea")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workout);
        }

        // GET: Workouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workout workout = db.Workouts.Find(id);
            db.Workouts.Remove(workout);
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
