using APTEKA_Software.Models;
using APTEKA_Software.Exeptions;

namespace APTEKA_Software.Repositories.Contracts
{
    public interface IItemRepository
    {
        List<Item> GetAllItems();
        Item GetById(int id);
        Item GetByName(string name);
        Item Create(Item item);
        Item Update(Item item);
        Item Delete(int id);
    }
}
