using System;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.SessionState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RateMyDebate.Controllers;
using RateMyDebate.Models;
using System.Web.Security;

namespace RateMyDebateTests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockRepo = new Mock<IDebateRepository>();
            
            DebateController controller = new DebateController(mockRepo.Object);

            var debate = new Debate
            {
                DebateId = 0, CategoryIdId = 4, CreatorIdId = 3, Live = true, 
                Subject = "Emne", Description = "Beskrivelse",
                DateTime = DateTime.Now, TimeLimit = 50
            };

            var result = controller.Create(debate) as RedirectResult;

            mockRepo.Verify(d => d.AddDebate(debate), Times.Once);
            mockRepo.Verify(d => d.Save(), Times.Once);

            Assert.IsNotNull(result);
        }
    }
}
