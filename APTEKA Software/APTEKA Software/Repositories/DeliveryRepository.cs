using APTEKA_Software.Data;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APTEKA_Software.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ApplicationContext context;

        public DeliveryRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Delivery> GetAllDeliveries()
        {
            return context.Deliveries.Include(d => d.Item).Include(d => d.User).ToList();
        }
        public Delivery GetDeliveryById(int id)
        {
            return context.Deliveries.Include(d => d.Item).Include(d => d.User).FirstOrDefault(d => d.DeliveryID == id);
        }
        public void AddDelivery(Delivery delivery)
        {
            delivery.DeliveryDate = DateTime.Now;
            context.Deliveries.Add(delivery);
            context.SaveChanges();
        }
        public void UpdateDelivery(Delivery delivery)
        {
            context.Deliveries.Update(delivery);
            context.SaveChanges();
        }
        public void DeleteDelivery(int id)
        {
            var delivery = context.Deliveries.Find(id);
            if (delivery != null)
            {
                context.Deliveries.Remove(delivery);
                context.SaveChanges();
            }
        }
    }
}
