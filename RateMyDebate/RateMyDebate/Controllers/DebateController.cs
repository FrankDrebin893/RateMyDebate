using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RateMyDebate.Models;

namespace RateMyDebate.Controllers
{
    public class DebateController : Controller
    {
        private RateMyDebateContext db = new RateMyDebateContext();

        // GET: /Debate/
        public ActionResult Index()
        {
            return View(db.Debate.ToList());
        }

        // GET: /Debate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debate debate = db.Debate.Find(id);
            if (debate == null)
            {
                return HttpNotFound();
            }
            return View(debate);
        }

        // GET: /Debate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Debate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DebateId,Subject,Description,ChatText,CreatorId,ChallengerId,DateTime")] Debate debate)
        {
            if (ModelState.IsValid)
            {
                db.Debate.Add(debate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(debate);
        }

        // GET: /Debate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debate debate = db.Debate.Find(id);
            if (debate == null)
            {
                return HttpNotFound();
            }
            return View(debate);
        }

        // POST: /Debate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DebateId,Subject,Description,ChatText,CreatorId,ChallengerId,DateTime")] Debate debate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(debate);
        }

        // GET: /Debate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debate debate = db.Debate.Find(id);
            if (debate == null)
            {
                return HttpNotFound();
            }
            return View(debate);
        }

        // POST: /Debate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Debate debate = db.Debate.Find(id);
            db.Debate.Remove(debate);
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
