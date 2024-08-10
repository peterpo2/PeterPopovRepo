using APTEKA_Software.Models;

namespace APTEKA_Software.Repositories.Contracts
{
    public interface IDeliveryRepository
    {
        List<Delivery> GetAllDeliveries();
        void MakeDelivery(Delivery delivery);

        void ReassignDeliveries(int oldUserId, int newUserId);
    }

}
