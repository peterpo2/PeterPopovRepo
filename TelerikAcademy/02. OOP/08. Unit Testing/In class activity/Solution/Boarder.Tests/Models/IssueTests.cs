using Boarder.Models;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Globalization;

namespace Boarder.Tests
{
    [TestClass]
    public class IssueTests
    {
        private const string DateFormat = "dd-MM-yyyy";
        private readonly CultureInfo CultureInfo = CultureInfo.InvariantCulture;

        [TestMethod]
        public void ShouldCreateIssueWhenParametersAreValid()
        {
            string title = "Title";
            string description = "Description";
            DateTime dueDate = DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo);

            Issue issue = new Issue(title, description, dueDate);

            Assert.AreEqual("Title", issue.Title);
        }

        [TestMethod]
        public void ShouldSetDescription()
        {
            Issue issue = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.AreEqual("Description", issue.Description);
        }

        [TestMethod]
        public void ShouldSetDueDate()
        {
            Issue issue = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.AreEqual(DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo), issue.DueDate);
        }

        [TestMethod]
        public void StatusShouldStartAtOpen()
        {
            Issue issue = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.AreEqual(Status.Open, issue.Status);
        }

        [TestMethod]
        public void ShouldAdvancedStatus()
        {
            Issue issue = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            issue.AdvanceStatus();

            Assert.AreEqual(Status.Verified, issue.Status);
        }

        [TestMethod]
        public void ShouldRevertStatus()
        {
            Issue issue = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            issue.AdvanceStatus();
            issue.RevertStatus();

            Assert.AreEqual(Status.Open, issue.Status);
        }

        [TestMethod]
        public void ShouldAddInfo()
        {
            Issue issue = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.IsNotNull(issue.ViewInfo());
        }

        [TestMethod]
        public void ShouldAddInEventLog()
        {
            var item = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            int actualCount = this.GetEventLogCount(item);
            Assert.AreEqual(expected: 1, actualCount);
        }

        [TestMethod]
        public void ReturnsCorrectType()
        {
            Issue issue = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.IsInstanceOfType(issue, typeof(Issue));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenTitleNameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(null, "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo)));
        }

        [TestMethod]
        [DataRow("Joe")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ShouldThrowAnExceptionWhenInvalidTitleLength(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(value, "Descritption", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo)));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenDueDateIsInThePast()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue("Title", "Assignee", DateTime.ParseExact("20-03-2000", DateFormat, CultureInfo)));
        }

        [TestMethod]
        public void ShouldHaveMessageIfThereIsNowDescription()
        {
            Issue issue = new Issue("Title", null, DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.IsNotNull(issue.Description);
        }

        [TestMethod]
        public void IssueShouldDeriveFromBoardItem()
        {
            var type = typeof(Issue);
            var isAssignable = typeof(BoardItem).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable);
        }

        [TestMethod]
        public void ShouldAddToLogWhenStatusAlreadyAtVerified()
        {
            var item = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
           
            item.AdvanceStatus();
            int expectedCount = this.GetEventLogCount(item) + 1;
            item.AdvanceStatus();
            int actualCount = this.GetEventLogCount(item);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void ShouldAddToLogWhenStatusAlreadyAtOpen()
        {
            var item = new Issue("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            int expectedCount = this.GetEventLogCount(item) + 1;
            
            item.RevertStatus();
            int actualCount = this.GetEventLogCount(item);
            
            Assert.AreEqual(expectedCount, actualCount);
        }

        private int GetEventLogCount(BoardItem item)
        {
            return item.ViewHistory().Split(Environment.NewLine).Length;
        }
    }
}
