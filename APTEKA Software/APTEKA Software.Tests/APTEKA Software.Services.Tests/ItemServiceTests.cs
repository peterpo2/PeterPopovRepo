using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services;
using APTEKA_Software.Services.Contracts;
using Moq;

namespace APTEKA_Software.Tests.APTEKA_Software.Services.Tests
{
    [TestClass]
    public class ItemServiceTests
    {
        private IItemService itemService;
        private Mock<IItemRepository> itemRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            itemRepositoryMock = new Mock<IItemRepository>();
            itemService = new ItemService(itemRepositoryMock.Object);
        }

        [TestMethod]
        public void TestGetAllItems()
        {
            // Arrange
            var itemList = new List<Item>
            {
                new Item { ItemId = 1, ItemName = "Item1", AvailableQuantity = 10, SalePrice = 5 },
                new Item { ItemId = 2, ItemName = "Item2", AvailableQuantity = 20, SalePrice = 9 },
            };
            itemRepositoryMock.Setup(repo => repo.GetAllItems()).Returns(itemList);

            // Act
            var result = itemService.GetAllItems();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(itemList.Count, result.Count);
            for (int i = 0; i < itemList.Count; i++)
            {
                Assert.AreEqual(itemList[i].ItemId, result[i].ItemId);
                Assert.AreEqual(itemList[i].ItemName, result[i].ItemName);
            }
            itemRepositoryMock.Verify(repo => repo.GetAllItems(), Times.Once);
        }

        [TestMethod]
        public void TestGetItemById_ExistingItem()
        {
            // Arrange
            int itemId = 1;
            var expectedItem = new Item { ItemId = itemId, ItemName = "Item1", AvailableQuantity = 10, SalePrice = 5 };
            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns(expectedItem);

            // Act
            var result = itemService.GetItemById(itemId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(itemId, result.ItemId);
            Assert.AreEqual(expectedItem.ItemName, result.ItemName);
            itemRepositoryMock.Verify(repo => repo.GetById(itemId), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void TestGetItemById_NonExistentItem()
        {
            // Arrange
            int itemId = 1;
            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns((Item)null);

            // Act & Assert
            var result = itemService.GetItemById(itemId);
        }

        [TestMethod]
        public void TestCreateItem_Success()
        {
            // Arrange
            var newItemDto = new ItemDto
            {
                ItemName = "NewItem",
                AvailableQuantity = 15,
                SalePrice = 7
            };

            var newItem = new Item
            {
                ItemName = newItemDto.ItemName,
                AvailableQuantity = newItemDto.AvailableQuantity,
                SalePrice = newItemDto.SalePrice,
                IsDeleted = false
            };

            itemRepositoryMock.Setup(repo => repo.Create(It.Is<Item>(item =>
                item.ItemName == newItemDto.ItemName &&
                item.AvailableQuantity == newItemDto.AvailableQuantity &&
                item.SalePrice == newItemDto.SalePrice &&
                item.IsDeleted == false))).Returns(newItem);

            // Act
            var result = itemService.CreateItem(newItemDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newItem.ItemName, result.ItemName);
            Assert.AreEqual(newItem.AvailableQuantity, result.AvailableQuantity);
            Assert.AreEqual(newItem.SalePrice, result.SalePrice);

            itemRepositoryMock.Verify(repo => repo.Create(It.IsAny<Item>()), Times.Once);
        }

        [TestMethod]
        public void TestUpdateItem_Success()
        {
            // Arrange
            int itemId = 1;
            var itemToUpdate = new Item { ItemId = itemId, ItemName = "ItemToUpdate", AvailableQuantity = 10, SalePrice = 5 };
            var updatedItem = new Item { ItemName = "UpdatedItem", SalePrice = 7 };
            itemRepositoryMock.Setup(repo => repo.GetById(itemId)).Returns(itemToUpdate);
            itemRepositoryMock.Setup(repo => repo.Update(itemToUpdate)).Returns(updatedItem);

            // Act
            var result = itemService.UpdateItem(itemId, updatedItem);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedItem.ItemName, result.ItemName);
            Assert.AreEqual(updatedItem.SalePrice, result.SalePrice);
            itemRepositoryMock.Verify(repo => repo.GetById(itemId), Times.Once);
            itemRepositoryMock.Verify(repo => repo.Update(itemToUpdate), Times.Once);
        }

        [TestMethod]
        public void TestDeleteItem_Success()
        {
            // Arrange
            int itemIdToDelete = 1;
            var itemToDelete = new Item { ItemId = itemIdToDelete };

            // Настройване на Delete да връща itemToDelete
            itemRepositoryMock.Setup(repo => repo.Delete(itemIdToDelete)).Returns(itemToDelete);

            // Act
            var result = itemService.DeleteItem(itemIdToDelete);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(itemIdToDelete, result.ItemId);

            // Проверка дали Delete е извикан по един път
            itemRepositoryMock.Verify(repo => repo.Delete(itemIdToDelete), Times.Once);
        }

        [TestMethod]
        public void TestDeleteItem_NonExistentItem()
        {
            // Arrange
            int itemIdToDelete = 1;

            // Настройване на Delete да връща null, за да представи ситуацията, че артикула не съществува
            itemRepositoryMock.Setup(repo => repo.Delete(itemIdToDelete)).Returns((Item)null);

            // Act
            var result = itemService.DeleteItem(itemIdToDelete);

            // Assert
            Assert.IsNull(result);

            // Проверка дали Delete е извикан по един път
            itemRepositoryMock.Verify(repo => repo.Delete(itemIdToDelete), Times.Once);
        }
    }
}
