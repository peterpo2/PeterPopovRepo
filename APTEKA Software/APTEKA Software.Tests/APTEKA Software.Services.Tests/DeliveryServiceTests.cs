using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services;
using APTEKA_Software.Services.Contracts;
using Moq;

namespace APTEKA_Software.Tests.APTEKA_Software.Services.Tests
{
    [TestClass]
    public class DeliveryServiceTests
    {
        private IDeliveryService deliveryService;
        private Mock<IDeliveryRepository> deliveryRepositoryMock;
        private Mock<IUserService> userServiceMock;
        private Mock<IItemService> itemServiceMock;
        private Mock<IItemRepository> itemRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            deliveryRepositoryMock = new Mock<IDeliveryRepository>();
            userServiceMock = new Mock<IUserService>();
            itemServiceMock = new Mock<IItemService>();
            itemRepositoryMock = new Mock<IItemRepository>();
            deliveryService = new DeliveryService(deliveryRepositoryMock.Object, userServiceMock.Object, itemServiceMock.Object, itemRepositoryMock.Object);
        }

        [TestMethod]
        public void TestCreateDelivery_Success()
        {
            // Arrange
            var itemViewModel = new ItemViewModel
            {
                UserId = 1,
                QuantityDelivered = 10
            };
            int itemId = 1;

            var user = new User
            {
                UserId = 1
            };

            var item = new Item
            {
                ItemId = itemId,
                AvailableQuantity = 15,
            };

            userServiceMock.Setup(repo => repo.GetUser(itemViewModel.UserId)).Returns(user);
            itemServiceMock.Setup(repo => repo.GetItemById(itemId)).Returns(item);
            deliveryRepositoryMock.Setup(repo => repo.MakeDelivery(It.IsAny<Delivery>()));

            // Act
            deliveryService.CreateDelivery(itemViewModel, itemId);

            // Assert
            userServiceMock.Verify(repo => repo.GetUser(itemViewModel.UserId), Times.Once);
            itemServiceMock.Verify(repo => repo.GetItemById(itemId), Times.Once);
        }

        [TestMethod]
        public void TestGetRemainingQuantity_ExistingItem()
        {
            // Arrange
            int itemId = 1;
            var item = new Item
            {
                ItemId = itemId,
                AvailableQuantity = 10
            };
            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns(item);

            // Act
            var result = deliveryService.GetRemainingQuantity(itemId);

            // Assert
            Assert.AreEqual(item.AvailableQuantity, result);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void TestGetRemainingQuantity_NonExistentItem()
        {
            // Arrange
            int itemId = 1;
            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns((Item)null);

            // Act & Assert
            var result = deliveryService.GetRemainingQuantity(itemId);
        }

        [TestMethod]
        public void TestMakeDelivery_Success()
        {
            // Arrange
            int userId = 1;
            int itemId = 1;
            int quantityDelivered = 5;

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

            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns(new Item
            {
                ItemId = itemId,
                AvailableQuantity = 10,
                SalePrice = 5
            });

            userServiceMock.Setup(repo => repo.GetUser(userId)).Returns(user);
            itemServiceMock.Setup(repo => repo.GetItemById(itemId)).Returns(item);
            deliveryRepositoryMock.Setup(repo => repo.MakeDelivery(It.IsAny<Delivery>()));

            // Act
            var result = deliveryService.MakeDelivery(userId, itemId, quantityDelivered);

            // Assert
            userServiceMock.Verify(repo => repo.GetUser(userId), Times.Once);
            itemServiceMock.Verify(repo => repo.GetItemById(itemId), Times.Once);
            deliveryRepositoryMock.Verify(repo => repo.MakeDelivery(It.IsAny<Delivery>()), Times.Once);

        }
    }
}
