using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using RateMyDebate.Models;
using RateMyDebate.ViewModels;

namespace RateMyDebate.Controllers
{
    public class DebateController : Controller
    {
        private RateMyDebateContext db = new RateMyDebateContext();
        private DebateUser VM = new DebateUser();
        
        // GET: /Debate/
        /*
        public ActionResult Index()
        {

            //return View(db.Debate.ToList());
            VM.User = db.UserInformation.ToList();
            VM.Debate = db.Debate.ToList();
            VM.Categories = db.Categories.ToList();

            return View(VM);
        }*/

        // GET: /Debate/
        public ActionResult Index(String category, String creator, String challenger)
        {
            List<Debate> myList = db.Debate.ToList().Where(x => x.Live.Equals(true)).ToList();

            var CategoryQry = from d in db.Categories
                           orderby d.CategoryName
                           select d.CategoryName;

            VM.User = db.UserInformation.ToList();
            VM.Debate = db.Debate.ToList();
            VM.Categories = db.Categories.ToList();


            if (!String.IsNullOrEmpty(category))
            {
                myList = myList.Where(x => x.CategoryId.CategoryName.Contains(category)).ToList();
            }

            if (!String.IsNullOrEmpty(creator))
            {
                myList = myList.Where(x => x.CreatorId.nickName.Contains(creator)).ToList();
            }

            if (!String.IsNullOrEmpty(challenger))
            {
                myList = myList.ToList().Where(x => x.ChallengerId.nickName.Contains(challenger)).ToList();
            }

            VM.Debate = myList;

            ViewBag.category = new SelectList(CategoryQry);

            
            return View(VM);
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

        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DebateDisplayViewModel DDVM = new DebateDisplayViewModel();

            DDVM.Debate = db.Debate.Find(id);

            /*
            DDVM.CreatorInformation = db.UserInformation.ToList();
            DDVM.ChallengerInformation = db.UserInformation.ToList();
            DDVM.Category = db.Categories.ToList();
            */
            UserInformation creator = db.UserInformation.Find(DDVM.Debate.CreatorId);
            DDVM.CreatorInformation = creator;

            UserInformation challenger = db.UserInformation.Find(DDVM.Debate.ChallengerId);
            DDVM.ChallengerInformation = challenger;

            Category category =  db.Categories.Find(DDVM.Debate.CategoryId);
            DDVM.Category = category;
            

            /*
           if (DDVM.Debate == null || DDVM.Category == null || DDVM.CreatorInformation == null || DDVM.ChallengerInformation == null)
            {
                return HttpNotFound();
            }*/
            return View(DDVM);
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
        public ActionResult Create([Bind(Include="DebateId,Subject,Description,ChatText,CreatorVotes,ChallengerVotes,Live,DateTime")] Debate debate)
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
        public ActionResult Edit([Bind(Include="DebateId,Subject,Description,ChatText,CreatorVotes,ChallengerVotes,Live,DateTime")] Debate debate)
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
