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
    public class WeightsController : Controller
    {
        private WorkoutContext db = new WorkoutContext();

        // GET: Weights
        public ActionResult Index()
        {
            var userWeightHist = db.UserWeightHist.Include(w => w.User);
            return View(userWeightHist.ToList());
        }

        // GET: Weights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weight weight = db.UserWeightHist.Find(id);
            if (weight == null)
            {
                return HttpNotFound();
            }
            return View(weight);
        }

        // GET: Weights/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Weights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,WeightDate,UserWeight")] Weight weight)
        {
            if (ModelState.IsValid)
            {
                db.UserWeightHist.Add(weight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", weight.UserID);
            return View(weight);
        }

        // GET: Weights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weight weight = db.UserWeightHist.Find(id);
            if (weight == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", weight.UserID);
            return View(weight);
        }

        // POST: Weights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,WeightDate,UserWeight")] Weight weight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", weight.UserID);
            return View(weight);
        }

        // GET: Weights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weight weight = db.UserWeightHist.Find(id);
            if (weight == null)
            {
                return HttpNotFound();
            }
            return View(weight);
        }

        // POST: Weights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weight weight = db.UserWeightHist.Find(id);
            db.UserWeightHist.Remove(weight);
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
