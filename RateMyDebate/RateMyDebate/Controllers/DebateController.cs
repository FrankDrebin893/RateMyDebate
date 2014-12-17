using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using RateMyDebate.Migrations;
using RateMyDebate.Models;
using RateMyDebate.ViewModels;

namespace RateMyDebate.Controllers
{
    public class DebateController : Controller
    {
        private RateMyDebateContext db = new RateMyDebateContext();
        private readonly IDebateRepository _debateRepository;


        public DebateController(IDebateRepository debateRepository)
        {
            _debateRepository = debateRepository;
        }
        
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
            DebateUser VM = new DebateUser();

            var CategoryQry = from d in db.Categories
                           orderby d.CategoryName
                           select d.CategoryName;

            VM.User = db.UserInformation.ToList();
            VM.Debate = db.Debate.ToList();
            VM.Categories = db.Categories.ToList();

            
            if (!String.IsNullOrEmpty(category))
            {
                myList = myList.Where(x => x.CategoryId.CategoryName.Equals(category)).ToList();
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
            UserInformation creator = db.UserInformation.Find(DDVM.Debate.CreatorIdId);
            DDVM.CreatorInformation = creator;

            UserInformation challenger = db.UserInformation.Find(DDVM.Debate.ChallengerIdId);
            DDVM.ChallengerInformation = challenger;

            Category category =  db.Categories.Find(DDVM.Debate.CategoryIdId);
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
            var CategoryQry = from d in db.Categories
                              orderby d.CategoryName
                              select d.CategoryName;

            var CategoryQryIds = from d in db.Categories
                              orderby d.CategoryName
                              select d.CategoryId;
            ViewData["Categories"] = new SelectList(CategoryQryIds, CategoryQry);
            return View();
        }

        // POST: /Debate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="creatorIdId,DebateId,Subject,Description,CategoryIdId,Timelimit")] Debate debate)
        {
            debate.DateTime = DateTime.Now;
            debate.Live = true;

            if (ModelState.IsValid)
            {
                _debateRepository.AddDebate(debate);
                _debateRepository.Save();
                String url = "LiveChat?id=" + debate.DebateId;
                return Redirect(url);
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

        public ActionResult LiveChat(int? id)
        {
            DebateDisplayViewModel DDVM = FindDebateDisplayViewModel(id);

            ViewBag.Title = DDVM.Debate.Subject;

            return View(DDVM);
        }

        [HttpPost]
        public void EnterChallenger(int debateId)
        {
            var user = Session["UserInfoSession"] as UserInformation;
            Debate debate = _debateRepository.FindDebate(debateId);

            if (debate.ChallengerIdId == null)
            {
                debate.ChallengerIdId = user.userInformationId;
                _debateRepository.UpdateDebate(debate);
                _debateRepository.Save();
            }
        }

        [HttpPost]
        public void SaveMessage(String sender, String message, int debateId)
        {
            message = message.Replace("\n", "");
            String formattedMessage = "\n" + "[" + DateTime.Now + "] " + sender + " : " + message;
            Debate debate = _debateRepository.FindDebate(debateId);
            debate.ChatText += formattedMessage;
            _debateRepository.UpdateDebate(debate);
            _debateRepository.Save();
        }

        public Debate FindDebate(int id)
        {
            Debate debate = _debateRepository.FindDebate(id);
            return debate;
        }

        public DebateDisplayViewModel FindDebateDisplayViewModel(int? id)
        {
            DebateDisplayViewModel DDVM = new DebateDisplayViewModel();

            DDVM.Debate = db.Debate.Find(id);
            UserInformation creator = db.UserInformation.Find(DDVM.Debate.CreatorIdId);
            DDVM.CreatorInformation = creator;

            UserInformation challenger = db.UserInformation.Find(DDVM.Debate.ChallengerIdId);
            DDVM.ChallengerInformation = challenger;

            Category category = db.Categories.Find(DDVM.Debate.CategoryIdId);
            DDVM.Category = category;

            return DDVM;
        }

        public ActionResult TimerTest()
        {
            return View();
        }

        public DebateDisplayViewModel FillDDVM(int? id)
        {
            DebateDisplayViewModel DDVM = new DebateDisplayViewModel();

            DDVM.Debate = db.Debate.Find(id);

            UserInformation creator = db.UserInformation.Find(DDVM.Debate.CreatorIdId);
            DDVM.CreatorInformation = creator;

            UserInformation challenger = db.UserInformation.Find(DDVM.Debate.ChallengerIdId);
            DDVM.ChallengerInformation = challenger;

            Category category = db.Categories.Find(DDVM.Debate.CategoryIdId);
            DDVM.Category = category;

            return DDVM;
        }

        public void PlaceVote(int debateId, int votePosition)
        {
            var user = Session["UserInfoSession"] as UserInformation;
            int voterId = user.userInformationId;

            Vote vote = FindVote(voterId, debateId);
            vote.VotePos = votePosition;

            if (ModelState.IsValid)
            {
                db.Entry(vote).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        
        public Vote FindVote(int voterId, int debateId)
        {
            Vote vote = db.Votes.Find(voterId, debateId);
            return vote;
        }

        public ActionResult ShowEndScreen(DebateDisplayViewModel ddvm)
        {
            
            return View();
        }

        public String ProcessDebateResult(int debateId)
        {
            Debate debate = _debateRepository.FindDebate(debateId);
            int creatorId = debate.CreatorIdId;
            int? challengerId = debate.ChallengerIdId;

            UserInformation creator = db.UserInformation.Find(creatorId);
            UserInformation challenger = db.UserInformation.Find(challengerId);

            String creatorNick = creator.nickName;
            String challengerNick = challenger.nickName;

            if (challengerId == null) return "As no challenger was found, the debate will end without a conclusion. Sorry folks!";

            Result result = new Result();
            result.DebateId = debateId;
            String endingSentence = "Not assigned";

            List<Vote> creatorVoteCount = db.Votes.ToList().Where(x => x.DebateId == debateId & x.VotePos == 1).ToList();
            List<Vote> challengerVoteCount =
                db.Votes.ToList().Where(x => x.DebateId == debateId & x.VotePos == 2).ToList();

            int creatorVotesNum = creatorVoteCount.Count();
            int challengerVotesNum = challengerVoteCount.Count();

            if (creatorVotesNum > challengerVotesNum)
            {
                result.WinnerId = creatorId;
                result.LoserId = challengerId;

                endingSentence = "Thank you for participating and spectating! The winner is " +
                 creatorNick + " with a score of " + result.CreatorVotesCount + " to " +
                 challengerNick + "'s score of " + result.ChallengerVotesCount;
            }
            else if (creatorVotesNum < challengerVotesNum)
            {
                result.WinnerId = challengerId;
                result.LoserId = creatorId;

                endingSentence = "Thank you for participating and spectating! The winner is " +
                 challengerNick + " with a score of " + result.ChallengerVotesCount + " to " +
                 creatorNick + "'s score of " + result.CreatorVotesCount;
            }
            else if (creatorVotesNum == challengerVotesNum)
            {
                result.Draw = true;

                endingSentence = "Thank you for participating and spectating! Unfortunately a winner could not be found as both participants had a vote count of " + creatorVotesNum;
            }

            result.CreatorVotesCount = creatorVotesNum;
            result.ChallengerVotesCount = challengerVotesNum;

            SaveResult(result);
            SetDebateInactive(debateId);

            return endingSentence;
        }


        public void SaveResult(Result result)
        {
            Result check = FindResult(result.DebateId);
            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    db.Results.Add(result);
                    db.SaveChanges();
                }
            }
            else if (check == result)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(result).State = EntityState.Unchanged;
                    db.SaveChanges();
                }
            }
            else if (check != result)
            {
                db.Entry(check).CurrentValues.SetValues(result);
                db.SaveChanges();
            }
        }

        public Result FindResult(int debateId)
        {
            Result result = db.Results.Find(debateId);
            return result;
        }

        public void SetDebateInactive(int debateId)
        {
            Debate debate = _debateRepository.FindDebate(debateId);
            debate.Live = false;
            if (ModelState.IsValid)
            {
                _debateRepository.UpdateDebate(debate);
                _debateRepository.Save();
            }
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
