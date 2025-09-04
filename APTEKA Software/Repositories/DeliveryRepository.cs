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
        public void ReassignDeliveries(int oldUserId, int newUserId)
        {
            var deliveries = context.Deliveries.Where(d => d.UserId == oldUserId).ToList();

            foreach (var delivery in deliveries)
            {
                delivery.UserId = newUserId;
            }

            context.SaveChanges();
        }
        public bool HasDeliveries(int userId)
        {
            return context.Deliveries.Any(d => d.UserId == userId);
        }

    }
}
