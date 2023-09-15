using APTEKA_Software.Data;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APTEKA_Software.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ApplicationContext context;

        public DeliveryRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Delivery> GetAllDeliveries()
        {
            return context.Deliveries.ToList();
        }
        public void MakeDelivery(Delivery delivery)
        {
            context.Deliveries.Add(delivery);
            context.SaveChanges();
        }
        public List<Delivery> GetDeliveriesByUserId(int userId)
        {
            return context.Deliveries.Where(delivery => delivery.UserId == userId).ToList();
        }
        public Delivery GetDeliveryById(int id)
        {
            return context.Deliveries.Include(d => d.Item).Include(d => d.User).FirstOrDefault(d => d.DeliveryId == id);
        }
    }
}
