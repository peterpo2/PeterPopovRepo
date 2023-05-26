using System;
using System.Collections.Generic;
using Cosmetics.Commands;
using Cosmetics.Commands.Contracts;
using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using Cosmetics.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cosmetics.Tests.Commands
{
    [TestClass]
    public class RemoveFromCategoryCommandTests
    {
        private IRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = TestHelpers.InitializeRepository();
        }

        [TestMethod]
        [DataRow(RemoveFromCategoryCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(RemoveFromCategoryCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_ArgumentCountDifferentThanExpected(int testSize)
        {
            // Arrange
            ICommand command = new RemoveFromCategoryCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_RemoveFromCategory_When_ArgumentsAreValid()
        {
            // Arrange
            Category category = TestHelpers.AddInitializedCategoryToRepo(repository);
            Product product = TestHelpers.AddInitializedProductToRepo(repository);
            category.AddProduct(product);
            List<string> commandParams = new List<string> { category.Name, product.Name };
            ICommand command = new RemoveFromCategoryCommand(commandParams, repository);

            // Act
            command.Execute();

            // Arrange
            Assert.AreEqual(0, category.Products.Count);
        }
    }
}
