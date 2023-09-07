using APTEKA_Software.Data;
using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APTEKA_Software.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationContext context;

        public ItemRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public List<Item> GetAllItems()
        {
            return context.Items.Include(i => i.User)
                                .Include(i => i.AvailableQuantity)
                                .Include(i => i.SalePrice)
                                .ToList();
        }
        public Item GetById(int id)
        {
            return context.Items.Include(i => i.User)
                                .Include(i => i.AvailableQuantity)
                                .Include(i => i.SalePrice)
                                .SingleOrDefault(i => i.Id == id)
                ?? throw new EntityNotFoundException($"Item with id={id} not found.");
        }
        public Item GetByName(string name)
        {
            return context.Items.Include(i => i.User)
                                .Include(i => i.AvailableQuantity)
                                .Include(i => i.SalePrice)
                                .SingleOrDefault(i => i.Name == name)
                ?? throw new EntityNotFoundException($"Item with name '{name}' not found.");
        }
        public List<Item> GetByUser(string username)
        {
            return context.Items.Include(i => i.User)
                                .Include(i => i.AvailableQuantity)
                                .Include(i => i.SalePrice)
                                .Where(i => i.User.Username == username).ToList();
        }
        public Item Create(Item item)
        {
            item.DateCreated = DateTime.Now;
            context.Items.Add(item);
            context.SaveChanges();
            return item;
        }
        public Item Update (Item item)
        {
            var updatedItem = context.Update(item);
            context.SaveChanges();
            return updatedItem.Entity;
        }
        public Item Delete (int id)
        {
            var itemToDelete = GetById(id);
            if (itemToDelete != null)
            {
                itemToDelete.IsDeleted = true;
                context.Update(itemToDelete);
                context.SaveChanges();
            }
            return itemToDelete;
        }
    }
}
