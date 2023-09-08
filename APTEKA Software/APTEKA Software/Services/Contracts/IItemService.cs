using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models;
using APTEKA_Software.Exeptions;

namespace APTEKA_Software.Services.Contracts
{
    public interface IItemService
    {
        Item CreateItem(ItemDto itemDto);
        Item DeleteItem(int itemId);
        Item GetItemById(int itemId);
        List<Item> GetAllItems();

        Item UpdateItem(int itemId, Item updatedItem);
    }
}
