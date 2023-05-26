using Boarder.Models;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Boarder.Tests
{
    [TestClass]
    public class TaskTests
    {
        private const string DateFormat = "dd-MM-yyyy";
        private readonly CultureInfo CultureInfo = CultureInfo.InvariantCulture;

        [TestMethod]
        public void ShouldCreateTaskWhenParamertersAreValid()
        {
            string title = "Title";
            string assignee = "Assignee";
            DateTime dueDate = DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo);

            Task task = new Task(title, assignee, dueDate);

            Assert.AreEqual("Title", task.Title);
        }

        [TestMethod]
        public void ShouldSetAssigne()
        {
            Task task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.AreEqual("Assignee", task.Assignee);
        }

        [TestMethod]
        public void ShouldSetDueDate()
        {
            Task task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.AreEqual(DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo), task.DueDate);
        }

        [TestMethod]
        public void StatusShouldStartAtOpen()
        {

            Task task = new Task("Title", "Description", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.AreEqual(Status.Todo, task.Status);
        }

        [TestMethod]
        public void ShouldAdvancedStatus()
        {
            Task task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            task.AdvanceStatus();

            Assert.AreEqual(Status.InProgress, task.Status);
        }

        [TestMethod]
        public void ShouldRevertStatus()
        {
            Task task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            task.AdvanceStatus();
            task.RevertStatus();

            Assert.AreEqual(Status.Todo, task.Status);
        }

        [TestMethod]
        public void ShouldAddInfo()
        {
            Task task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.IsNotNull(task.ViewInfo());
        }

        [TestMethod]
        public void ShouldAddInEventLog()
        {
            var item = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            int actualCount = this.GetEventLogCount(item);
            Assert.AreEqual(expected: 1, actualCount);
        }

        [TestMethod]
        public void ReturnsCorrectType()
        {

            Task task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.IsInstanceOfType(task, typeof(Task));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow(" ")]

        public void ShouldThrowAnExceptionWhenAssigneeNameIsNullOrWhitespace(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Task("Test title", value, DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo)));
        }

        [TestMethod]
        [DataRow("Joe")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ShouldThrowAnExceptionWhenInvalidAssigneeLength(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Task("Test title", value, DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo)));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenTitleNameIsCultureInfo()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Task(null, "Assignee", DateTime.Now));
        }

        [TestMethod]
        [DataRow("ivo")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ShouldThrowAnExceptionWhenInvalidTitleLength(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Task(value, "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo)));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenDueDateIsInThePast()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Task("Title", "Assignee", DateTime.ParseExact("20-03-2000", DateFormat, CultureInfo)));
        }

        [TestMethod]
        public void TaskShouldDeriveFromBoardItem()
        {
            var type = typeof(Task);
            var isAssignable = typeof(BoardItem).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable);
        }

        [TestMethod]
        public void ShouldAddToEventLogWhenStatusAtVerified()
        {
            var item = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            item.AdvanceStatus();
            item.AdvanceStatus();
            item.AdvanceStatus();

            int expectedCount = this.GetEventLogCount(item) + 1;
            item.AdvanceStatus();
            int actualCount = this.GetEventLogCount(item);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void ShouldAddToEventLogWhenAssigneeChanged()
        {
            var item = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            int expectedCount = this.GetEventLogCount(item) + 1;

            item.Assignee = "Changed Assignee";
            int actualCount = this.GetEventLogCount(item);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void ShouldAddToEventLogWhenStatusAtToDo()
        {
            Task item = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
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
