using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RateMyDebate.Controllers;
using RateMyDebate.Models;
using RateMyDebate.ViewModels;
using System.Web.WebPages;

namespace RateMyDebateTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IDebateRepository debateRepository;

        [TestMethod]
        public void DebateTest()
        {
            DebateController controller = new DebateController(debateRepository);

            DebateDisplayViewModel result = controller.FindDebateDisplayViewModel(1) as DebateDisplayViewModel;

            Assert.AreEqual(1, result.Debate.CreatorIdId);
        }

        [TestMethod]
        public void DebateTest2()
        {
            DebateController controller = new DebateController(debateRepository);

            var result = controller.LiveChat(1) as ViewResult;

            Assert.AreEqual("Cake", result.ViewBag.Title);
        }

        [TestMethod]
        public void DebateDisplayTest()
        {
            DebateController controller = new DebateController(debateRepository);

            ViewResult result = controller.Display(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DebateDisplayTest2()
        {
            DebateController controller = new DebateController(debateRepository);

            var result = controller.Display(1) as ViewResult;
            
            var model = result.ViewData.Model as DebateDisplayViewModel;

            Assert.AreEqual(1, model.Debate.DebateId);
        }

        // Checking to make sure that debate list is not empty, when no filter parameters are parsed and database is not empty.
        [TestMethod]
        public void DebateIndexTest()
        {
            DebateController controller = new DebateController(debateRepository);

            var result = controller.Index(null, null, null) as ViewResult;

            var model = result.ViewData.Model as DebateUser;

            var list = model.Debate;

            Assert.AreNotEqual(0, list.Count); ;
        }

        // Testing to make sure the debate list is NOT empty,
        // when parsing through a search keyword that we know to exist in the database.
        [TestMethod]
        public void DebateIndexTest2()
        {
            DebateController controller = new DebateController(debateRepository);

            var result = controller.Index("Atheism", null, null) as ViewResult;

            var model = result.ViewData.Model as DebateUser;

            var list = model.Debate;

            Assert.AreNotEqual(0, list.Count);
        }


        // Testing to make sure the debate list contains 0 elements,
        // when parsing through a search keyword that we know not to exist in the database.
        [TestMethod]
        public void DebateIndexTest3()
        {
            DebateController controller = new DebateController(debateRepository);

            var result = controller.Index(null, "asdasdasdas", null) as ViewResult;

            var model = result.ViewData.Model as DebateUser;

            var list = model.Debate;

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void DebateProcessingTest()
        {
            DebateController controller = new DebateController(debateRepository);
            Debate debate = controller.FindDebate(1);
            int debateId = debate.DebateId;

            controller.ProcessDebateResult(debateId);

            Result result = controller.FindResult(debateId);

            int? winnerId = result.WinnerId;

            Assert.AreEqual(1, winnerId);
        }
        
        [TestMethod]
        public void DebateProcessingTest2()
        {

            DebateController controller = new DebateController(debateRepository);
            Debate debate = controller.FindDebate(2);
            int debateId = debate.DebateId;

            controller.ProcessDebateResult(debateId);

            Result result = controller.FindResult(debateId);

            int? winnerId = result.WinnerId;

            Assert.AreEqual(2, winnerId);
        }

        [TestMethod]
        public void DebateInactiveTest()
        {
            DebateController controller = new DebateController(debateRepository);

            int debateId = 1;

            controller.SetDebateInactive(1);

            Debate debate = controller.FindDebate(1);

            Assert.IsFalse(debate.Live);
        }
    }
}