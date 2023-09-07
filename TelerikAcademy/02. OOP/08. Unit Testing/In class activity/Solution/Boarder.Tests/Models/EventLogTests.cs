using Boarder.Models;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boarder.Tests
{
    [TestClass]
    public class EventLogTests
    {
        [TestMethod]
        public void ShouldSetDescription()
        {
            EventLog log = new EventLog("Event Log");

            Assert.AreEqual("Event Log", log.Description);
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescriptionIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
             new EventLog(null));
        }

        [TestMethod]
        public void ShouldShowInfo()
        {
            EventLog log = new EventLog("Event Log");

            Assert.IsNotNull(log.ViewInfo());
        }

        [TestMethod]
        public void ReturnsCorrectType()
        {
            EventLog log = new EventLog("Event Log");

            Assert.IsInstanceOfType(log, typeof(EventLog));
        }

    }
}
