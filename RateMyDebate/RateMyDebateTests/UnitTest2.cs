using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateMyDebate.Controllers;
using RateMyDebate.Models;

namespace RateMyDebateTests
{
    [TestClass]
    public class UnitTest2
    {
        private readonly IDebateRepository debateRepository;
        [TestMethod]
        public void VoteTest1()
        {
            DebateController controller = new DebateController(debateRepository);

            Vote vote = controller.FindVote(9, 1);

            int testPos = vote.VotePos;

            Assert.AreEqual(1, testPos);
        }

        [TestMethod]
        public void VoteTest2()
        {
            DebateController controller = new DebateController(debateRepository);

            Vote vote = controller.FindVote(9, 2);

            int testPos = vote.VotePos;

            Assert.AreEqual(2, testPos);
        }

        [TestMethod]
        public void VoteTest3()
        {
            DebateController controller = new DebateController(debateRepository);

            Vote vote = controller.FindVote(8, 2);

            int testPos = vote.VotePos;

            Assert.AreEqual(1, testPos);
        }
    }
}
