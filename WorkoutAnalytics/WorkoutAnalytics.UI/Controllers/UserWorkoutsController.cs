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
    public class UserWorkoutsController : Controller
    {
        private WorkoutContext db = new WorkoutContext();

        // GET: UserWorkouts
        public ActionResult Index()
        {
            var userWorkouts = db.UserWorkouts.Include(u => u.User).Include(u => u.Workout);
            return View(userWorkouts.ToList());
        }

        // GET: UserWorkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            if (userWorkout == null)
            {
                return HttpNotFound();
            }
            return View(userWorkout);
        }

        // GET: UserWorkouts/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "WorkoutBodyArea");
            return View();
        }

        // POST: UserWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserWorkoutID,WorkoutID,WorkoutDesc,UserID,WeightLifted,TimeOfWorkout,Distance,DistanceUnits,WeightUnits,SentimentID,WorkoutDate,Reps")] UserWorkout userWorkout)
        {
            if (ModelState.IsValid)
            {
                db.UserWorkouts.Add(userWorkout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", userWorkout.UserID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "WorkoutBodyArea", userWorkout.WorkoutID);
            return View(userWorkout);
        }

        // GET: UserWorkouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            if (userWorkout == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", userWorkout.UserID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "WorkoutBodyArea", userWorkout.WorkoutID);
            return View(userWorkout);
        }

        // POST: UserWorkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserWorkoutID,WorkoutID,WorkoutDesc,UserID,WeightLifted,TimeOfWorkout,Distance,DistanceUnits,WeightUnits,SentimentID,WorkoutDate,Reps")] UserWorkout userWorkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userWorkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", userWorkout.UserID);
            ViewBag.WorkoutID = new SelectList(db.Workouts, "WorkoutID", "WorkoutBodyArea", userWorkout.WorkoutID);
            return View(userWorkout);
        }

        // GET: UserWorkouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            if (userWorkout == null)
            {
                return HttpNotFound();
            }
            return View(userWorkout);
        }

        // POST: UserWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            db.UserWorkouts.Remove(userWorkout);
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
