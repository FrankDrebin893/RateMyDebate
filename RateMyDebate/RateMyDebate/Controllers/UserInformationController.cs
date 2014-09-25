using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RateMyDebate.Models;
using System.Web.UI;
using System.Collections;

namespace RateMyDebate.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
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

           //var userTry = from m in db.UserModel where m.accountId.Equals(userinformation.accountId.accountId) select m;
           
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
                var crypto = new SimpleCrypto.PBKDF2();

                var encryptPass = crypto.Compute(id.Password);
                id.Password = encryptPass;
                id.ConfirmPassword = crypto.Compute(id.ConfirmPassword);
                id.Salt = crypto.Salt;
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
            if (Session["UserInfoSession"] != null)
            {
                var session = Session["UserinfoSession"] as UserInformation;
                if(session.userInformationId == id){
                    UserInformation userinformation = db.UserInformation.Find(id);
                    userinformation.accountId = db.UserModel.Find(userinformation.userId);
                    if (userinformation == null)
                    {
                        return HttpNotFound();
                    }
                    return View(userinformation);
                }
            }
            ViewBag.Error = "Error!";
            return View("UserEditError");
        }

        // POST: /UserInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( UserInformation userinformation)
        {

            // GG  this SOAB [Bind(Include="userInformationId,fName,lName,nickName,age,autobiography,Email")] Delete dat shit son! Reminder.....
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
            if (Session["UserInfoSession"] != null)
            {
                var session = Session["UserinfoSession"] as UserInformation;
                if (session.userInformationId == id)
                {
                    UserInformation userinformation = db.UserInformation.Find(id);
                    userinformation.accountId = db.UserModel.Find(userinformation.userId);
                    if (userinformation == null)
                    {
                        return HttpNotFound();
                    }
                    return View(userinformation);
                }
            }
            return View("UserEditError");
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
        public ActionResult profile()
        {
            UserInformation user = new UserInformation();
            UserModel sessionUser = Session["userSession"] as UserModel;
            int id = sessionUser.accountId;

            var user1 = db.UserInformation.FirstOrDefault(u => u.userId == id);

            user = user1;
           
            return View(user);
        }

        public ActionResult Profiles(String SearchName)
        {
            List<UserInformation> user;
            user = db.UserInformation.ToList();
           // ViewBag.NotFound = "";
            if(SearchName != null){
           
                user = db.UserInformation.Where(u => u.nickName == SearchName).ToList();
                if (user.Count() == 0)
                {
                    ViewBag.NotFound = "User not found! Check your spelling!";
                    return View(user);
                }
            }
            return View(user);
        }


        public ActionResult Edit2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session["UserSession"] != null)
            {
                var session = Session["UserSession"] as UserModel;
                if (session.accountId == id)
                {
                    UserModel usermodel = db.UserModel.Find(id);
                   // usermodel.accountId = db.UserModel.Find(userinformation.userId);
                    if (usermodel == null)
                    {
                        return HttpNotFound();
                    }
                    return View(usermodel);
                }
            }
            return View("UserEditError");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2(UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                usermodel.Password = crypto.Compute(usermodel.Password);
                usermodel.ConfirmPassword = crypto.Compute(usermodel.ConfirmPassword);
                usermodel.Salt = crypto.Salt;
                db.Entry(usermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("profile");
            }
            return View(usermodel);
        }

        [HttpPost]
        public JsonResult ValidateNickName(string nickName)
        {
            // !db.UserModel.Any(user => user.userName == userName

            //!db.UserModel.Any(user => user.userName.Equals(userName)

            var usercheck = db.UserInformation.FirstOrDefault(user => user.nickName.Equals(nickName));

            return Json(usercheck == null);

        }
       
    }
}
