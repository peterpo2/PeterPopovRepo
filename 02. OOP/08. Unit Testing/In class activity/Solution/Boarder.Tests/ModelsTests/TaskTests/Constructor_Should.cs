using Boarder.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Boarder.Tests.ModelsTests.TaskTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CorrectlyAssignTitle()
        {
            //Arrange
            var title = "This is a test title";
            var assignee = "TestUser";
            var dueDate = Convert.ToDateTime("01-01-2030");

            //Act
            var sut = new Task(title, assignee, dueDate);

            //Assert
            Assert.AreEqual(title, sut.Title);
        }

        [TestMethod]
        public void CorrectlyAssignAssignee()
        {
            //Arrange
            var title = "This is a test title";
            var assignee = "TestUser";
            var dueDate = Convert.ToDateTime("01-01-2030");

            //Act
            var sut = new Task(title, assignee, dueDate);

            //Assert
            Assert.AreEqual(assignee, sut.Assignee);
        }

        [TestMethod]
        public void CorrectlyAssignDueDate()
        {
            //Arrange
            var title = "This is a test title";
            var assignee = "TestUser";
            var dueDate = Convert.ToDateTime("01-01-2030");

            //Act
            var sut = new Task(title, assignee, dueDate);

            //Assert
            Assert.AreEqual(dueDate, sut.DueDate);
        }

        [TestMethod]
        public void CorrectlyAssignStatus()
        {
            //Arrange
            var title = "This is a test title";
            var assignee = "TestUser";
            var dueDate = Convert.ToDateTime("01-01-2030");

            //Act
            var sut = new Task(title, assignee, dueDate);

            //Assert
            Assert.AreEqual(Status.Todo, sut.Status);
        }

        [TestMethod]
        public void CallAddEventLog()
        {
            //Arrange
            var title = "This is a test title";
            var assignee = "TestUser";
            var dueDate = Convert.ToDateTime("01-01-2030");
            var expectedInfo = "Task: 'This is a test title', [Todo|01-01-2030] Assignee: TestUser";

            //Act
            var sut = new Task(title, assignee, dueDate);

            //Assert
            Assert.AreEqual(expectedInfo, sut.ViewInfo()); // here we depend on proper implementation of ViewInfo() so our test is not independent.
        }
    }
}
