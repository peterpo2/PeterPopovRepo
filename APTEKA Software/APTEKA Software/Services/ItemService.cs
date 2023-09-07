using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;
using APTEKA_Software.Exeptions;

namespace APTEKA_Software.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }
        public List<Item> GetAllItems()
        {
            return this.itemRepository.GetAllItems();
        }
        public Item GetItemById(int itemId)
        {
            var item = this.itemRepository.GetById(itemId);
            if (item == null)
            {
                throw new EntityNotFoundException($"Артикул ={item} не съществува.");
            }
            return item;
        }
        public Item CreateItem(ItemDto itemDto, User user)
        {
            var item = new Item
            {
                Name = itemDto.Name,
                IsDeleted = false,
                User = user

            };
            var createdItem = this.itemRepository.Create(item);
            return createdItem;
        }
        public Item UpdateItem(int itemId, Item updatedItem, User user)
        {
            var item = this.itemRepository.GetById(itemId);
            if (item == null)
            {
                throw new EntityNotFoundException($"Артикул ={item} не съществува.");
            }
            item.Name = updatedItem.Name;
            item.SalePrice = updatedItem.SalePrice;

            this.itemRepository.Update(item);

            return item;
        }
        public bool DeleteItem(int itemId)
        {
            var item = this.itemRepository.GetById(itemId);
            if (item == null)
                return false;
            item.IsDeleted = true;
            var deletedItem = this.itemRepository.Update(item);
            return deletedItem != null;
        }
    }
}
