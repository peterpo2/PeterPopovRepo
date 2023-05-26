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
    public class AddToShoppingCartCommandTests
    {
        private IRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = TestHelpers.InitializeRepository();
        }

        [TestMethod]
        [DataRow(AddToShoppingCartCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(AddToShoppingCartCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_ArgumentCountDifferentThanExpected(int testSize)
        {
            // Arrange
            ICommand command = new AddToShoppingCartCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_AddToShoppingCart_When_ArgumentsAreValid()
        {
            // Arrange
            Product product = TestHelpers.AddInitializedProductToRepo(repository);
            ICommand command = new AddToShoppingCartCommand(new List<string> { product.Name }, repository);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(1, repository.ShoppingCart.Products.Count);
        }
    }
}
