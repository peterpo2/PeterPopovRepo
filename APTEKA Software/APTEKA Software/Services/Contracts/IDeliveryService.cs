using APTEKA_Software.Models;

namespace APTEKA_Software.Services.Contracts
{
    public interface IDeliveryService
    {
        IEnumerable<Delivery> GetAllDeliveries();
        Delivery GetDeliveryById(int id);
        void AddDelivery(Delivery delivery);
        void UpdateDelivery(Delivery delivery);
        void DeleteDelivery(int id);
    }
}
