using RateMyDebate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RateMyDebate.Controllers
{
    public class HomeController : Controller
    {
        private RateMyDebateContext db = new RateMyDebateContext();
        public ActionResult Index()
        {
            //YO
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult RasmusIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.userLogonModel user)
        {


            var usermodel = db.UserModel.FirstOrDefault(u => u.userName == user.userName);
            if (ModelState.IsValid)
            {
                
                if(IsValid(user.userName, user.Password)){

                FormsAuthentication.SetAuthCookie(user.userName, false);
                return RedirectToAction("RasmusIndex", "Home");
                }
                  else
                {
                ModelState.AddModelError("", "Logins is wrong");
                }
            }

            return View(usermodel);
        }

        private bool IsValid(string userName, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool isValid = false;
            using (var db = new RateMyDebateContext())
            {
                var user = db.UserModel.FirstOrDefault(u => u.userName == userName);
                var userinfo = db.UserInformation.FirstOrDefault(u => u.userId == user.accountId);
                if(user != null){
                    if (user.Password == crypto.Compute(password, user.Salt))
                    {
                        Session["UserSession"] = user;
                        Session["UserInfoSession"] = userinfo;
                        isValid = true;
                    }
                }
               
            }
            


            return isValid;
        }
        public ActionResult LogOut(){

            Session["UserSession"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("RasmusIndex", "Home");
        }
    }
}