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
        //private RateMyDebateContext db = new RateMyDebateContext();
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
        public ActionResult Login(Models.UserModel user)
        {
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
            return View(user);
        }

        private bool IsValid(string userName, string password)
        {
            bool isValid = false;
            using (var db = new RateMyDebateContext())
            {
                var user = db.UserModel.FirstOrDefault(u => u.userName == userName);
                
                if(user != null){
                    if (user.Password == password)
                    {
                        Session["UserSession"] = user;
                        isValid = true;
                    }
                }
               
            }
            


            return isValid;
        }
        public ActionResult LogOut(){

            FormsAuthentication.SignOut();
            return RedirectToAction("RasmusIndex", "Home");
        }
    }
}