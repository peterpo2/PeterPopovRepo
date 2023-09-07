using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;

namespace APTEKA_Software.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            this.deliveryRepository = deliveryRepository;
        }
        public IEnumerable<Delivery> GetAllDeliveries()
        {
            return deliveryRepository.GetAllDeliveries();
        }
        public Delivery GetDeliveryById(int id)
        {
            return deliveryRepository.GetDeliveryById(id);
        }
        public void AddDelivery(Delivery delivery)
        {
            deliveryRepository.AddDelivery(delivery);
        }
        public void UpdateDelivery(Delivery delivery)
        {
            deliveryRepository.UpdateDelivery(delivery);
        }
        public void DeleteDelivery(int id)
        {
            deliveryRepository.DeleteDelivery(id);
        }
    }
}
