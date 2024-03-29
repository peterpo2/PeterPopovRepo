﻿using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services;
using APTEKA_Software.Services.Contracts;
using Moq;

namespace APTEKA_Software.Tests.APTEKA_Software.Services.Tests
{
    [TestClass]
    public class SalesServiceTests
    {
        private ISalesService salesService;
        private Mock<IItemRepository> itemRepositoryMock;
        private Mock<IUserRepository> userRepositoryMock;
        private Mock<ISaleRepository> saleRepositoryMock;
        private Mock<IUserService> userServiceMock;
        private Mock<IItemService> itemServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            itemRepositoryMock = new Mock<IItemRepository>();
            userRepositoryMock = new Mock<IUserRepository>();
            saleRepositoryMock = new Mock<ISaleRepository>();
            userServiceMock = new Mock<IUserService>();
            itemServiceMock = new Mock<IItemService>();
            salesService = new SalesService(itemRepositoryMock.Object, userRepositoryMock.Object, saleRepositoryMock.Object, userServiceMock.Object, itemServiceMock.Object);
        }
        [TestMethod]
        public void TestMakeSale_Success()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            int quantity = 5;

            var user = new User
            {
                UserId = userId
            };

            var item = new Item
            {
                ItemId = itemId,
                AvailableQuantity = 10,
                SalePrice = 5
            };

            userRepositoryMock.Setup(repo => repo.GetUser(userId)).Returns(user);
            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns(item);

            // Act
            var result = salesService.MakeSale(userId, itemId, quantity);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(quantity * item.SalePrice, result.TotalSaleValue);
            Assert.AreEqual(item.AvailableQuantity, result.RemainingQuantity);
        }
        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void TestMakeSale_InsufficientQuantity()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            int quantity = 15;

            var user = new User
            {
                UserId = userId
            };

            var item = new Item
            {
                ItemId = itemId,
                AvailableQuantity = 10,
                SalePrice = 5
            };

            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns(item);
            userRepositoryMock.Setup(repo => repo.GetUser(userId)).Returns(user);

            // Act & Assert
            salesService.MakeSale(userId, itemId, quantity);
        }
        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void TestMakeSale_UserOrItemNotFound()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            int quantity = 5;

            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns((Item)null);
            userRepositoryMock.Setup(repo => repo.GetUser(userId)).Returns((User)null);

            // Act & Assert
            salesService.MakeSale(userId, itemId, quantity);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCreateSale_InsufficientQuantity()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            int quantitySold = 15;

            var user = new User
            {
                UserId = userId
            };

            var item = new Item
            {
                ItemId = itemId,
                AvailableQuantity = 10,
                SalePrice = 5
            };

            var itemViewModel = new ItemViewModel
            {
                UserId = userId,
                QuantitySold = quantitySold
            };

            userServiceMock.Setup(repo => repo.GetUser(userId)).Returns(user);
            itemServiceMock.Setup(repo => repo.GetItemById(itemId)).Returns(item);

            // Act & Assert
            salesService.CreateSale(itemViewModel, itemId);
        }
        [TestMethod]
        public void TestGetAllSales_Success()
        {
            // Arrange
            var salesData = new List<Sale>
            {
                new Sale { SaleId = 1, UserId = 1, ItemId = 1, SaleDate = DateTime.Now, QuantitySold = 5, TotalAmount = 25 },
                new Sale { SaleId = 2, UserId = 2, ItemId = 2, SaleDate = DateTime.Now, QuantitySold = 3, TotalAmount = 15 },
                new Sale { SaleId = 3, UserId = 1, ItemId = 2, SaleDate = DateTime.Now, QuantitySold = 2, TotalAmount = 10 },
            };

            saleRepositoryMock.Setup(repo => repo.GetAll()).Returns(salesData);

            // Act
            var result = salesService.GetAllSales();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(salesData.Count, result.Count);
            Assert.AreEqual(salesData[0].UserId, result[0].UserId);
        }

        [TestMethod]
        public void TestGetRemainingQuantity_Success()
        {
            // Arrange
            int itemId = 1;
            var item = new Item
            {
                ItemId = itemId,
                AvailableQuantity = 10,
                SalePrice = 5
            };

            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns(item);

            // Act
            var result = salesService.GetRemainingQuantity(itemId);

            // Assert
            Assert.AreEqual(item.AvailableQuantity, result);
        }
        [TestMethod]
        public void TestCreateSale_Success()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            int quantitySold = 5;

            var user = new User
            {
                UserId = userId
            };

            var item = new Item
            {
                ItemId = itemId,
                AvailableQuantity = 10,
                SalePrice = 5
            };

            var itemViewModel = new ItemViewModel
            {
                UserId = userId,
                QuantitySold = quantitySold
            };

            userServiceMock.Setup(repo => repo.GetUser(userId)).Returns(user);
            itemServiceMock.Setup(repo => repo.GetItemById(itemId)).Returns(item);

            // Act
            try
            {
                salesService.CreateSale(itemViewModel, itemId);

                // Assert
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception: {ex.Message}");
            }
        }
        [TestMethod]
        public void TestGetSalesByUserId_ReturnsSalesForUser()
        {
            // Arrange
            int userId = 1;
            var sales = new List<Sale>
        {
            new Sale { SaleId = 1, UserId = userId },
            new Sale { SaleId = 2, UserId = userId },
            new Sale { SaleId = 3, UserId = 2 }, // Sale not related to the user
        };
            saleRepositoryMock.Setup(repo => repo.GetAll()).Returns(sales);

            // Act
            var result = salesService.GetSalesByUserId(userId);

            // Assert
            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2 }, result.Select(s => s.SaleId).ToList());
        }

        [TestMethod]
        public void TestGetSaleViewModelsByUserId_ReturnsSaleViewModelsForUser()
        {
            // Arrange
            int userId = 1;
            var sales = new List<Sale>
        {
            new Sale { SaleId = 1, UserId = userId, ItemId = 101 },
            new Sale { SaleId = 2, UserId = userId, ItemId = 102 },
        };
            var user = new User { UserId = userId, Username = "User1" };
            var items = new List<Item>
        {
            new Item { ItemId = 101, ItemName = "Item1" },
            new Item { ItemId = 102, ItemName = "Item2" },
        };

            saleRepositoryMock.Setup(repo => repo.GetAll()).Returns(sales);
            userServiceMock.Setup(repo => repo.GetUser(userId)).Returns(user);
            itemServiceMock.Setup(repo => repo.GetItemById(It.IsAny<int>())).Returns<int>((id) => items.FirstOrDefault(item => item.ItemId == id));

            // Act
            var result = salesService.GetSaleViewModelsByUserId(userId);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(user.Username, result[0].UserName);
            Assert.AreEqual("Item1", result[0].ItemName);
            Assert.AreEqual("Item2", result[1].ItemName);
        }
    }
}
