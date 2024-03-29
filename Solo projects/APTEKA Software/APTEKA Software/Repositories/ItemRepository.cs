﻿using APTEKA_Software.Data;
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
            return context.Items.ToList();
        }

        public Item GetById(int Id)
        {
            var item = context.Items.FirstOrDefault(i => i.ItemId == Id);

            if (item == null)
            {
                throw new EntityNotFoundException($"Артикул с идентификационен номер {Id} не беше намерен.");
            }

            return item;
        }


        public Item GetByName(string name)
        {
            return context.Items.FirstOrDefault(i => i.ItemName == name)
                ?? throw new EntityNotFoundException($"Артикул с име '{name}' не беше намерен.");
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
