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
    public class UserInformationController : Controller
    {
        private RateMyDebateContext db = new RateMyDebateContext();

        // GET: /UserInformation/
        public ActionResult Index()
        {
            return View(db.UserInformation.ToList());
        }

        // GET: /UserInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            UserInformation userinformation = db.UserInformation.Find(id);
            int i = userinformation.userId;
          //  var user = from m in db.UserInformation where m.userInformationId == id select m;

           // var userTry = from m in db.UserModel where m.accountId.Equals(userinformation.accountId.accountId) select m;
           
            //userinformation.accountId = db.UserModel.Find(36);
            

            if (userinformation == null)
            {
                return HttpNotFound();
            }
            return View(userinformation);
        }

        // GET: /UserInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="userInformationId,fName,lName,nickName,age,autobiography,Email")] UserInformation userinformation)
        {
            if (ModelState.IsValid)
            {
                var id = TempData["Id"] as UserModel;
            
                userinformation.accountId = id;
                
                db.UserInformation.Add(userinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinformation);
        }

        // GET: /UserInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userinformation = db.UserInformation.Find(id);
            if (userinformation == null)
            {
                return HttpNotFound();
            }
            return View(userinformation);
        }

        // POST: /UserInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="userInformationId,fName,lName,nickName,age,autobiography,Email")] UserInformation userinformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userinformation);
        }

        // GET: /UserInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userinformation = db.UserInformation.Find(id);
            if (userinformation == null)
            {
                return HttpNotFound();
            }
            return View(userinformation);
        }

        // POST: /UserInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInformation userinformation = db.UserInformation.Find(id);
            db.UserInformation.Remove(userinformation);
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
