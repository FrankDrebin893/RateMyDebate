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
    public class MessageController : Controller
    {
        private RateMyDebateContext db = new RateMyDebateContext();

        // GET: /Message/
        public ActionResult Index()
        {
            UserInformation infoUser = new UserInformation();

            if(Session["UserSession"] != null){
                var user = Session["UserSession"];
                UserModel userr = user as UserModel;
                var usermodel = db.UserInformation.FirstOrDefault(u => u.userId == userr.accountId);
                infoUser = usermodel;
                var message = db.Message.Include(m => m.inboxId).Include(m => m.userInformation).Where(m => m.userId == infoUser.userId);
                return View(message.ToList());
            }
            
            return View("NotLoggedIn");
        }

        // GET: /Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: /Message/Create
        public ActionResult Create()
        {
            
            
            return View();
        }

        // POST: /Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Message message)
        {
            
            if (Session["UserSession"] != null)
            {
                var user = Session["UserSession"] as UserModel;
                message.Sender = user.userName;
                if(message.Receiver != null){
                    
                  var usermodel = db.UserModel.FirstOrDefault(u => u.userName == message.Receiver);
                  if(usermodel != null)
                  {
                    var receiverUser = db.UserInformation.FirstOrDefault(u => u.userId == usermodel.accountId);                 
                    message.userId = receiverUser.userInformationId;
                    message.inboxKey = 1;
                  }
                  else
                  {
                      message = null;
                      ModelState.AddModelError("Receiver","Receiver Doesn't exist in user database! Make sure the name is spelled correct!");
                  }
                    
                }

            }
            if (ModelState.IsValid)
            {
                db.Message.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(message);
        }

        // GET: /Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.inboxKey = new SelectList(db.Inbox, "inboxId", "inboxId", message.inboxKey);
            ViewBag.userId = new SelectList(db.UserInformation, "userInformationId", "fName", message.userId);
            return View(message);
        }

        // POST: /Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="messageId,userId,inboxKey,subject,messageText")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.inboxKey = new SelectList(db.Inbox, "inboxId", "inboxId", message.inboxKey);
            ViewBag.userId = new SelectList(db.UserInformation, "userInformationId", "fName", message.userId);
            return View(message);
        }

        // GET: /Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Message.Find(id);
            db.Message.Remove(message);
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
