using Cosmetics.Commands;
using Cosmetics.Commands.Contracts;
using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Tests.Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Tests.Commands
{
    [TestClass]
    public class CreateCategoryCommandTests
    {
        private IRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = new Repository();
        }

        [TestMethod]
        [DataRow(CreateCategoryCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(CreateCategoryCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_InvalidArgumentsCount(int testSize)
        {
            // Arrange
            ICommand command = new CreateCategoryCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_NameExists()
        {
            // Arrange
            IList<string> commandParameters = new string[] { TestData.CategoryData.ValidName }.ToList();
            ICommand command = new CreateCategoryCommand(commandParameters, repository);
            command.Execute();

            ICommand commandCategoryExists = new CreateCategoryCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => commandCategoryExists.Execute());
        }

        [TestMethod]
        public void Should_CreateCategory_When_ArgumentsAreValid()
        {
            // Arrange
            ICommand command = new CreateCategoryCommand(new List<string>() { TestData.CategoryData.ValidName }, repository);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(1, repository.Categories.Count);
            Assert.AreEqual(TestData.CategoryData.ValidName, repository.Categories[0].Name);
        }
    }
}
