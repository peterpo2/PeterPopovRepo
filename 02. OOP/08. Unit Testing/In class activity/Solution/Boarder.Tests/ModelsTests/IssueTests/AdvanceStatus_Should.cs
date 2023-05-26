using Boarder.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boarder.Tests.ModelsTests.IssueTests
{
    [TestClass]
    public class AdvanceStatus_Should
    {
        [TestMethod]
        public void CorrectlyAdvanceStatus()
        {
            //Arrange
            var title = "This is a test issue";
            var description = "This is a valid description";
            var dueDate = Convert.ToDateTime("01-01-2030");
            var sut = new Issue(title, description, dueDate);

            //Act
            sut.AdvanceStatus();

            //Assert
            Assert.IsTrue(sut.Status == Status.Verified);
        }
    }
}
