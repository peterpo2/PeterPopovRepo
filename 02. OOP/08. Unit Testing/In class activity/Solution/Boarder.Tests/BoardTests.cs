using Boarder.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Boarder.Tests
{
    [TestClass]
    public class BoardTests
    {
        private const string DateFormat = "dd-MM-yyyy";
        private readonly CultureInfo CultureInfo = CultureInfo.InvariantCulture;

        [TestMethod]
        public void ShouldAddBoardItemToList()
        {
            BoardItem task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            Board.AddItem(task);

            Assert.IsNotNull(Board.TotalItems);
        }

        [TestMethod]
        public void ShouldThrowAnExceptionIfItemAlreadyExicsts()
        {
            BoardItem task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            Board.AddItem(task);

            Assert.ThrowsException<InvalidOperationException>(() => Board.AddItem(task));
        }


        [TestMethod]
        public void ViewHistoryShouldReturnString()
        {
            BoardItem task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));

            Assert.IsNotNull(task.ViewHistory());
        }

        [TestMethod]
        public void ShouldAddToHistoryWhenDueDateChanged()
        {
            // Arrange
            BoardItem task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            int expectedCount = this.GetEventLogCount(task) + 1;
            // Act
            task.DueDate = DateTime.ParseExact("21-03-2030", DateFormat, CultureInfo);
            int actualCount = this.GetEventLogCount(task);
            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void ShouldAddToLogWhenTitleChanged()
        {
            BoardItem task = new Task("Title", "Assignee", DateTime.ParseExact("20-03-2030", DateFormat, CultureInfo));
            int logCount = task.ViewHistory().Split(Environment.NewLine).Length;
            task.Title = "Test Title";

            Assert.AreEqual(logCount + 1, task.ViewHistory().Split(Environment.NewLine).Length);
        }

        private int GetEventLogCount(BoardItem item)
        {
            return item.ViewHistory().Split(Environment.NewLine).Length;
        }
    }
}
