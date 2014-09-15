using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RateMyDebate.Models;
using RateMyDebate.ViewModels;
using System.Web.UI;

namespace RateMyDebate.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class UserController : Controller
    {
        private RateMyDebateContext db = new RateMyDebateContext();
        private UserCreateViewModel vm = new UserCreateViewModel();
        private UserModel newUserModel = new UserModel();
        // GET: /User/
        public ActionResult Index()
        {
            
            return View(db.UserModel.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel usermodel = db.UserModel.Find(id);

            UserModel userSession = Session["userSession"] as UserModel;
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel usermodel)
        {

            
            if (ModelState.IsValid)
            {
                //var id = usermodel;

               // db.UserModel.Add(usermodel);
               //db.SaveChanges();
                
                TempData["Id"] = usermodel;

                return RedirectToAction("Create", "UserInformation");
            }

            return View(usermodel);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel usermodel = db.UserModel.Find(id);
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="accountId,userName,Password")] UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usermodel);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel usermodel = db.UserModel.Find(id);
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserModel usermodel = db.UserModel.Find(id);
            db.UserModel.Remove(usermodel);
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

        [HttpPost]
        public JsonResult ValidateUserName(string userName)
        {
           // !db.UserModel.Any(user => user.userName == userName

            //!db.UserModel.Any(user => user.userName.Equals(userName)
            
            var usercheck = db.UserModel.FirstOrDefault(user => user.userName.Equals(userName));
            
            return Json(usercheck == null);
            
        }

        
    }
}
