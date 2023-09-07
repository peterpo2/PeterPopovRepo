using Boarder.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Boarder.Tests.ModelsTests.TaskTests
{
    [TestClass]
    public class Assignee_Should
    {
        [TestMethod]
        public void Throw_When_AssigneeIsNull_Ver1()
        {
            //Arrange
            var title = "This is a test title";
            var assignee = "TestUser";
            var dueDate = Convert.ToDateTime("01-01-2030");
            var sut = new Task(title, assignee, dueDate);

            //Act & Assert
            var result = Assert.ThrowsException<ArgumentException>(() => sut.Assignee = null);
            Assert.AreEqual("Please provide a non-null or empty value", result.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please provide a non-null or empty value")]
        public void Throw_When_AssigneeIsNull_Ver2()
        {
            //Arrange
            var title = "This is a test title";
            var assignee = "TestUser";
            var dueDate = Convert.ToDateTime("01-01-2030");
            var sut = new Task(title, assignee, dueDate);

            //Act & Assert
            sut.Assignee = null;
        }
    }
}
