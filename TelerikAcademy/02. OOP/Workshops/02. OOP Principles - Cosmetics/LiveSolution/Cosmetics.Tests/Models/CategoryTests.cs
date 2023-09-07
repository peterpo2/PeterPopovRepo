using Cosmetics.Models;
using Cosmetics.Models.Contracts;
using Cosmetics.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using static Cosmetics.Tests.Helpers.TestData;

namespace Cosmetics.Tests.Models
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Constructor_Should_ThrowException_When_NameLengthOutOfBounds()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Category(CategoryData.InvalidName));
        }

        [TestMethod]
        public void Constructor_Should_CreateCategory_When_NameIsValid()
        {
            ICategory category = new Category(CategoryData.ValidName);

            Assert.AreEqual(CategoryData.ValidName, category.Name);
        }

        [TestMethod]
        public void Constructor_Should_InitializeNewListOfProducts_When_CategoryCreated()
        {
            ICategory category = TestHelpers.InitializeCategory();

            Assert.IsNotNull(category.Products);
        }

        [TestMethod]
        public void AddProduct_Should_AddProductToList()
        {
            // Arrange
            ICategory category = TestHelpers.InitializeCategory();
            IProduct productToAdd = TestHelpers.InitializeTestProduct();

            // Act
            category.AddProduct(productToAdd);

            // Assert
            Assert.AreEqual(1, category.Products.Count);
        }

        [TestMethod]
        public void RemoveProduct_Should_ThrowException_When_ProductNotFound()
        {
            // Arrange
            ICategory category = TestHelpers.InitializeCategory();
            IProduct product = TestHelpers.InitializeTestProduct();

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => category.RemoveProduct(product));
        }

        [TestMethod]
        public void RemoveProduct_Should_RemoveProductFromList()
        {
            // Arrange
            ICategory category = TestHelpers.InitializeCategory();
            IProduct product = TestHelpers.InitializeTestProduct();
            category.AddProduct(product);

            // Act
            category.RemoveProduct(product);

            // Assert
            Assert.AreEqual(0, category.Products.Count);
        }
    }
}
