using Cosmetics.Commands;
using Cosmetics.Commands.Contracts;
using Cosmetics.Core.Contracts;
using Cosmetics.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cosmetics.Tests.Commands
{
    [TestClass]
    public class CreateCategoryCommandTests
    {
        private IRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = TestHelpers.InitializeRepository();
        }

        [TestMethod]
        [DataRow(CreateCategoryCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(CreateCategoryCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_ArgumentCountDifferentThanExpected(int testSize)
        {
            // Arrange
            ICommand command = new CreateCategoryCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_CategoryWithSameNameExists()
        {
            // Arrange
            List<string> commandParameters = new List<string>() { TestData.CategoryData.ValidName };
            ICommand command = new CreateCategoryCommand(commandParameters, repository);
            command.Execute();

            // Act, Assert
            ICommand commandCategoryExists = new CreateCategoryCommand(commandParameters, repository);
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_Create_When_ArgumentsAreValid()
        {
            // Arrange
            ICommand command = new CreateCategoryCommand(new List<string>() { TestData.CategoryData.ValidName }, repository);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(1, repository.Categories.Count);
        }
    }
}
