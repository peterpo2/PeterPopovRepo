using Cosmetics.Commands;
using Cosmetics.Commands.Contracts;
using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using Cosmetics.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cosmetics.Tests.Commands
{
    [TestClass]
    public class AddToCategoryCommandTests
    {
        private IRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = TestHelpers.InitializeRepository();
        }

        [TestMethod]
        [DataRow(AddToCategoryCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(AddToCategoryCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_ArgumentCountDifferentThanExpected(int testSize)
        {
            // Arrange
            ICommand command = new AddToCategoryCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_AddToCategory_When_ArgumentsAreValid()
        {
            // Arrange
            Category category = TestHelpers.AddInitializedCategoryToRepo(repository);
            Product product = TestHelpers.AddInitializedProductToRepo(repository);
            List<string> commandParams = new List<string> { category.Name, product.Name };
            ICommand command = new AddToCategoryCommand(commandParams, repository);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(1, repository.Categories.Count);
        }
    }
}
