using APTEKA_Software.Data;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;

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
    }
}
