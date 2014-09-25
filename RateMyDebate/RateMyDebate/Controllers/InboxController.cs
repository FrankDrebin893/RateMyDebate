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
    public class InboxController : Controller
    {
        private RateMyDebateContext db = new RateMyDebateContext();

        // GET: /Inbox/
        public ActionResult Index()
        {
            var inbox = db.Inbox.Include(i => i.userInformation);
          //  var inboxtry = db
            return View(inbox.ToList());
        }

        // GET: /Inbox/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inbox inbox = db.Inbox.Find(id);
            if (inbox == null)
            {
                return HttpNotFound();
            }
            return View(inbox);
        }

        // GET: /Inbox/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.UserInformation, "userInformationId", "fName");
            return View();
        }

        // POST: /Inbox/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="inboxId,userId")] Inbox inbox)
        {
            if (ModelState.IsValid)
            {
                db.Inbox.Add(inbox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.UserInformation, "userInformationId", "fName", inbox.userId);
            return View(inbox);
        }

        // GET: /Inbox/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inbox inbox = db.Inbox.Find(id);
            if (inbox == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.UserInformation, "userInformationId", "fName", inbox.userId);
            return View(inbox);
        }

        // POST: /Inbox/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="inboxId,userId")] Inbox inbox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inbox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.UserInformation, "userInformationId", "fName", inbox.userId);
            return View(inbox);
        }

        // GET: /Inbox/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inbox inbox = db.Inbox.Find(id);
            if (inbox == null)
            {
                return HttpNotFound();
            }
            return View(inbox);
        }

        // POST: /Inbox/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inbox inbox = db.Inbox.Find(id);
            db.Inbox.Remove(inbox);
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
