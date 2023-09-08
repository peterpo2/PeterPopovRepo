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
            return context.Items
                .Include(i => i.User)
                .ToList();
        }

        public Item GetById(int Id)
        {
            return context.Items
                .Include(i => i.User)
                .FirstOrDefault(i => i.Id == Id)
                ?? throw new EntityNotFoundException($"Артикул с идентификационен номер {Id} не беше намерен.");
        }

        public Item GetByName(string name)
        {
            return context.Items
                .Include(i => i.User)
                .SingleOrDefault(i => i.Name == name)
                ?? throw new EntityNotFoundException($"Артикул с име '{name}' не беше намерен.");
        }

        public List<Item> GetByUser(string username)
        {
            return context.Items
                .Include(i => i.User)
                .Where(i => i.User.Username == username)
                .ToList();
        }

        public Item Create(Item item)
        {
            item.DateCreated = DateTime.Now;
            context.Items.Add(item);
            context.SaveChanges();
            return item;
        }

        public Item Update(Item item)
        {
            var updatedItem = context.Update(item);
            context.SaveChanges();
            return updatedItem.Entity;
        }

        public Item Delete(int id)
        {
            var itemToDelete = GetById(id);
            if (itemToDelete != null)
            {
                context.Items.Remove(itemToDelete);
                context.SaveChanges();
            }
            return itemToDelete;
        }
    }
}
