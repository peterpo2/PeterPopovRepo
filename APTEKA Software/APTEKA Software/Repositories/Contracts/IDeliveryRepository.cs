using APTEKA_Software.Models;

namespace APTEKA_Software.Repositories.Contracts
{
    public interface IDeliveryRepository
    {
        List<Delivery> GetAllDeliveries();
        Delivery MakeDelivery(Delivery delivery);
        Delivery GetDeliveryById(int id);
        List<Delivery> GetDeliveriesByUserId(int userId);
    }
}
