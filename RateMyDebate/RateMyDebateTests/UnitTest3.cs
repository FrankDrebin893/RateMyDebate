using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RateMyDebate.Controllers;
using RateMyDebate.Models;

namespace RateMyDebateTests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new Mock<IDebateRepository>();

            controller.Object.DeleteDebate(1);

            Assert.IsNull(controller.Object.FindDebate(1));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var controller = new Mock<IDebateRepository>();

            Debate debate = controller.Object.FindDebate(2);

            Assert.IsNotNull(controller.Object.FindDebate(2));
        }
    }
}
