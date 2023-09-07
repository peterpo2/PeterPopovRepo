using APTEKA_Software.Models;

namespace APTEKA_Software.Repositories.Contracts
{
    public interface IDeliveryRepository
    {
        IEnumerable<Delivery> GetAllDeliveries();
        Delivery GetDeliveryById(int id);
        void AddDelivery(Delivery delivery);
        void UpdateDelivery(Delivery delivery);
        void DeleteDelivery(int id);
    }
}
