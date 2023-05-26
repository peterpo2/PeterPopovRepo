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
    public class RemoveFromShoppingCartCommandTests
    {
        private IRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = TestHelpers.InitializeRepository();
        }

        [TestMethod]
        [DataRow(RemoveFromShoppingCartCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(RemoveFromShoppingCartCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_ArgumentCountDifferentThanExpected(int testSize)
        {
            // Arrange
            ICommand command = new RemoveFromShoppingCartCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_RemoveFromShoppingCart_When_ArgumentsAreValid()
        {
            // Arrange
            Product product = TestHelpers.AddInitializedProductToRepo(repository);
            repository.ShoppingCart.AddProduct(product);
            ICommand command = new RemoveFromShoppingCartCommand(new List<string> { product.Name }, repository);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(0, repository.ShoppingCart.Products.Count);
        }
    }
}
