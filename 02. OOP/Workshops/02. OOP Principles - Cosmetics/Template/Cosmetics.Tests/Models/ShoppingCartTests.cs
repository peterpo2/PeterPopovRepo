using Cosmetics.Models;
using Cosmetics.Models.Contracts;
using Cosmetics.Tests.Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Cosmetics.Tests.Models
{
    [TestClass]
    public class ShoppingCartTests
    {
        private ShoppingCart cart;

        [TestInitialize]
        public void SetUp()
        {
            cart = new ShoppingCart();
        }

        [TestMethod]
        public void Constructor_Should_InitializeNewListOfProducts()
        {
            Assert.IsNotNull(cart.Products);
        }

        [TestMethod]
        public void GetProducts_Should_ReturnCopyOfTheCollection()
        {
            // Arrange
            IProduct productToAdd = TestHelpers.InitializeTestProduct();

            // Act
            cart.Products.Add(productToAdd);

            // Act
            Assert.AreEqual(0, cart.Products.Count);
        }

        [TestMethod]
        public void AddProduct_Should_AddProductToList()
        {
            // Arrange, Act
            IProduct productToAdd = TestHelpers.InitializeTestProduct();
            cart.AddProduct(productToAdd);

            // Assert
            Assert.AreEqual(1, cart.Products.Count);
        }

        [TestMethod]
        public void RemoveProduct_Should_ThrowException_When_ProductNotInCart()
        {
            // Arrange
            IProduct product = TestHelpers.InitializeTestProduct();

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => cart.RemoveProduct(product));
        }

        [TestMethod]
        public void RemoveProduct_Should_RemoveProductFromList()
        {
            // Arrange
            IProduct product = TestHelpers.InitializeTestProduct();
            cart.AddProduct(product);

            // Act
            cart.RemoveProduct(product);

            // Assert
            Assert.AreEqual(0, cart.Products.Count);
        }

        [TestMethod]
        public void ContainsProduct_Should_ReturnTrue_When_ProductFound()
        {
            // Arrange
            IProduct product = TestHelpers.InitializeTestProduct();
            cart.AddProduct(product);

            // Act
            bool isFound = cart.ContainsProduct(product);

            // Assert
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void ContainsProduct_Should_ReturnFalse_When_ProductNotFound()
        {
            // Arrange
            IProduct product = TestHelpers.InitializeTestProduct();

            // Act
            bool isFound = cart.ContainsProduct(product);

            // Assert
            Assert.IsFalse(isFound);
        }
    }
}
